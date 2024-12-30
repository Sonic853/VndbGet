using System.Data;
using System.Text;
using MiniExcelLibs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VndbGet
{
    public partial class VndbGetForm : Form
    {
        string url = "https://api.vndb.org/kana/vn";
        string[] fields = [];
        string[] ids = [];
        public VndbGetForm()
        {
            InitializeComponent();
        }

        private void VndbGetForm_Load(object sender, EventArgs e)
        {

        }
        private async void SendButton_Click(object sender, EventArgs e)
        {
            await SendRequest();
        }
        async Task SendRequest()
        {
            vndbToolStripStatusLabel.Text = "Sending request...";
            url = urlTextBox.Text;
            if (string.IsNullOrEmpty(url)) { return; }
            fields = fieldsTextBox.Text.Trim().Split(',').Select(x => x.Trim()).ToArray();
            ids = iDTextBox.Text.Trim().Split('\n').Select(x => x.Trim()).ToArray();
            using var httpClient = new HttpClient();
            // ,[\"id\", \"=\", \"v17\"]
            var filters = ids.Select(x => $",[\"id\", \"=\", \"{x}\"]").ToArray();
            var jsonBody = $"{{\"filters\":[\"or\"{string.Join("", filters)}],\"fields\":\"{string.Join(",", fields)}\"}}";
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            vndbToolStripStatusLabel.Text = "Request sent";
            // vndbToolStripStatusLabel.Text = jsonBody;
            var response = await httpClient.PostAsync(url, content);
            vndbToolStripStatusLabel.Text = "Parsing response...";
            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(result))
            {
                vndbToolStripStatusLabel.Text = "ReadAsStringAsync is empty";
            }
            var jobj = JObject.Parse(result);
            if (!jobj.ContainsKey("results"))
            {
                vndbToolStripStatusLabel.Text = "No results found";
                return;
            }
            var _results = jobj["results"];
            if (_results == null)
            {
                vndbToolStripStatusLabel.Text = "results is null";
                return;
            }
            var results = (JArray)_results;
            if (results == null)
            {
                vndbToolStripStatusLabel.Text = "results is not array";
                return;
            }
            var dataKeyValues = new Dictionary<string, List<object>>();
            foreach (JObject item in results.Cast<JObject>())
            {
                ProcessJObject(item);
            }

            var numRows = dataKeyValues.Values.Max(x => x.Count);
            var rows = new List<Dictionary<string, object>>();

            for (int i = 0; i < numRows; i++)
            {
                var row = new Dictionary<string, object>();

                // 先添加 id 列
                if (dataKeyValues.ContainsKey("id"))
                {
                    row["id"] = dataKeyValues["id"].Count > i ? dataKeyValues["id"][i] : "";
                }
                foreach (var kvp in dataKeyValues)
                {
                    if (kvp.Key != "id")
                    {
                        row[kvp.Key] = kvp.Value.Count > i ? kvp.Value[i] : "";
                    }
                }
                rows.Add(row);
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx|CSV Files|*.csv|All Files|*.*",
                Title = "保存为",
                DefaultExt = "csv",
                FileName = $"output_{(DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000}",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (File.Exists(filePath))
                    File.Delete(filePath);
                vndbToolStripStatusLabel.Text = $"Save...";
                await MiniExcel.SaveAsAsync(filePath, rows);
                vndbToolStripStatusLabel.Text = $"{filePath} Save Done";
            }

            void ProcessJObject(JObject jObject, string parentKey = "")
            {
                foreach (var property in jObject.Properties())
                {
                    string key = parentKey == "" ? property.Name : $"{parentKey}.{property.Name}";

                    if (property.Value.Type == JTokenType.Object)
                    {
                        ProcessJObject((JObject)property.Value, key);
                    }
                    else
                    {
                        if (!dataKeyValues.ContainsKey(key))
                        {
                            dataKeyValues.Add(key, []);
                        }

                        dataKeyValues[key].Add(property.Value);
                    }
                }
            }
        }
    }
}
