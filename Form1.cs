using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace TinyScanner 
{
    public partial class Form1 : Form
    {
        string pattern = @"(int|float|string|read|write|repeat|until|if|elseif|else|then|return|endl)|""[^""]*""|\/\*.*?\*\/
                        |[a-zA-Z][a-zA-Z0-9]*|[0-9]+(\.[0-9]+)?|:=|\+|\-|\*|\/|<|>|=|<>|&&|\|\||\(|\)|\{|\}|;|,";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string code = textBox1.Text;

            MatchCollection matches = Regex.Matches(code, pattern);

            foreach (Match m in matches)
            {
                string Type = m.Value;
                string token = "";

                if (Regex.IsMatch(Type, @"^(int|float|string|read|write|repeat|until|if|elseif|else|then|return|endl)$"))
                    token = "Keyword";

                else if (Regex.IsMatch(Type, @"^[a-zA-Z][a-zA-Z0-9]*$"))
                    token = "Identifier";

                else if (Regex.IsMatch(Type, @"^[0-9]+(\.[0-9]+)?$"))
                    token = "Number";

                else if (Regex.IsMatch(Type, @"^\""[^\""]*\""$"))
                    token = "String";

                else if (Regex.IsMatch(Type, @"^:=|\+|\-|\*|\/$"))
                    token = "Operator";

                else if (Regex.IsMatch(Type, @"^<|>|=|<>$"))
                    token = "Condition Operator";

                else if (Regex.IsMatch(Type, @"^&&|\|\|$"))
                    token = "Boolean Operator";

                else
                    token = "Symbol";

                dataGridView1.Rows.Add(Type, token);
            }
        }
    }
}
