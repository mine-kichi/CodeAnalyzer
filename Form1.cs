using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CodeAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
/*            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var lines = File.ReadAllLines(openFileDialog.FileName);
                var modifiedLines = ModifyLines(lines);
                File.WriteAllLines(openFileDialog.FileName, modifiedLines);
                MessageBox.Show("File modified successfully!");
            }*/

        }

        private string[] ModifyLines(string[] lines)
        {
            var modifiedLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                modifiedLines.Add(lines[i]);

                if (lines[i].EndsWith(")"))
                {
                    modifiedLines.Add("任意の文字"); // Insert arbitrary text
                }
            }
            return modifiedLines.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
/*            string path = @"D:\work\programming\github\Tools\CodeAnalyzer\test\test.c"; // C言語ソースコードへのパスを指定します
            string pattern = @"(\w+)\s+(\w+)\s*\((.*?)\)"; // 基本的な関数宣言の正規表現パターン
            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    Console.WriteLine("Function name: " + match.Groups[2].Value); // 抽出した関数名を表示します
                }
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
/*            string path = @"D:\work\programming\github\Tools\CodeAnalyzer\test\test.c"; // C言語ソースコードへのパスを指定します
            string pattern = @"(\w+)\s+(\w+)\s*\((.*?)\)"; // 基本的な関数宣言の正規表現パターン
//            string pattern = @"(\w+)\s+(\w+)\s*\((.*?)\)\s*\{";
            string appendString = "\n\tprintf(\"Inside function\\n\");"; // 追加するprintf文

            string outputPath = @"D:\work\programming\github\Tools\CodeAnalyzer\test\test_after.c"; // C言語ソースコードへのパスを指定します
            string[] lines = File.ReadAllLines(path);

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var line in lines)
                {
                    var match = Regex.Match(line, pattern);

                    if (match.Success)
                    {
                        string newLine = Regex.Replace(line, @"\{", "{" + appendString);
//                        string newLine = Regex.Replace(line, @"\{", "{" + "aaaaa");
                        Console.WriteLine(newLine); // 抽出した関数名を表示します
                        writer.WriteLine(newLine); // 新しい行をファイルに書き出します
                    }
                    else
                    {
                        writer.WriteLine(line); // 関数定義がない行はそのまま書き出します
                    }
                }
            }
*/        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = @textBox1.Text; // C言語ソースコードへのパスを指定します
            string filePath = Path.GetDirectoryName(textBox1.Text);
            string fileName = Path.GetFileName(textBox1.Text);
            string fileExtention = Path.GetExtension(textBox1.Text);

            string pattern = @"(\w+)\s+(\w+)\s*\((.*?)\)\s*";
            string appendString = "\tprintf(\"Inside function\\n\");"; // 追加するprintf文


            string outputPath = filePath + "\\" + fileName + "_test" + fileExtention;

            string[] lines = File.ReadAllLines(path);

            bool functionStartNextLine = false; // 関数の開始が次の行にある場合にtrueになります

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var line in lines)
                {
                    var match = Regex.Match(line, pattern);

                    if (match.Success)
                    {
                        functionStartNextLine = true;
                    }

                    if (functionStartNextLine && line.Trim().StartsWith("{"))
                    {
                        functionStartNextLine = false;
                        string newLine = line.Replace("{", "{\n" + appendString);

                        writer.WriteLine(newLine); // 新しい行をファイルに書き出します
                        continue;
                    }

                    writer.WriteLine(line); // 関数定義がない行はそのまま書き出します
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // OpenFileDialogオブジェクトの生成
            OpenFileDialog od = new OpenFileDialog();
            od.Title = "ファイルを開く";  //ダイアログ名
            od.FileName = @"sample.c";  //初期選択ファイル名
            od.Filter = "Cソースファイル(*.c;*.cpp)|*.c;*.cpp|すべてのファイル(*.*)|*.*";  //選択できる拡張子
            od.FilterIndex = 1;  //初期の拡張子

            // ダイアログを表示する
            DialogResult result = od.ShowDialog();


            // 選択後の判定
            if (result == DialogResult.OK)
            {
                //「開く」ボタンクリック時の処理
                string fileName = od.FileName;  //これで選択したファイルパスを取得できる
                textBox1.Text = fileName;
            }
            else if (result == DialogResult.Cancel)
            {
                //「キャンセル」ボタンクリック時の処理
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
