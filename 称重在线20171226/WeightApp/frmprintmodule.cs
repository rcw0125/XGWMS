using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FastReport;

namespace WeightApp
{
    public partial class frmprintmodule : Form
    {
        public frmprintmodule()
        {
            InitializeComponent();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmprintmodule_Load(object sender, EventArgs e)
        {
            listmodule();
        }
        private string[] ListDirs(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            DirectoryInfo[] items = d.GetDirectories();
            string fl="";
            foreach (DirectoryInfo item in items)
            {
                fl += item.Name+",";
            }
            string[] tl;
            if (fl.Length > 0) fl = fl.Substring(0,fl.Length-1);
            tl = fl.Split(',');
            return tl;
        }
        private void listmodule()
        {
            dgvm.Rows.Clear();
            dgv.Rows.Clear();
            string PrintModule = Public.GetXmlValue("PrintModuleName");
            if (PrintModule == "") PrintModule = "标准模板";
            string[] tl = null;
            tl=ListDirs(Application.StartupPath + "\\report");
            foreach (string s in tl)
            {
                string isck = "false";
                if (PrintModule == s) isck = "true";
                string[] r ={ s, isck };
                dgvm.Rows.Add(r);
            }
            dgvm.Rows[0].Selected=true;
            
        }
        private void findfile(string path)
        {
            dgv.Rows.Clear();
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo f in dir.GetFiles("*.fr3 "))
            {
                string name = f.Name;
                string namef = "";
                if (name=="ckcz.fr3") namef="出口材标签";
                if (name == "ptcz.fr3") namef = "标准普通材标签";
                if (name == "ptcz1.fr3") namef = "普通材标签不带属性和特殊信息";
                if (name == "ptcz2.fr3") namef = "普通材标签带属性";
                if (name == "ptcz3.fr3") namef = "普通材标签带特殊信息";
                if (name == "ptcz4.fr3") namef = "普通材标签带属性和特殊信息";
                if (name == "ptcz5.fr3") namef = "R1/2属性标签";
                string[] r = { name, namef };
                dgv.Rows.Add(r);
            }

        }
        private void dgvm_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvm.SelectedRows.Count == 0) return;
            string modulename = dgvm.SelectedRows[0].Cells[0].Value.ToString();
            string f = Application.StartupPath + "\\report\\" + modulename;
            if (!Directory.Exists(f)) return;
            findfile(f);
        }

        private void btn_lbdesign_Click(object sender, EventArgs e)
        {
            if (dgvm.SelectedRows.Count == 0) return;
            if (dgv.SelectedRows.Count == 0) return;
            string modename = dgvm.SelectedRows[0].Cells[0].Value.ToString();
            string lbname = dgv.SelectedRows[0].Cells[0].Value.ToString();
            if (modename == "标准模板")
            {
                MessageBox.Show("标准模板不允许设计！", "系统提示");
                return;
            }
            string filefullpath = Application.StartupPath + "\\report\\" + modename + "\\" + lbname;
            TfrxReportClass Report = Report = new TfrxReportClass();
            if (!File.Exists(filefullpath))
            {
                MessageBox.Show("标签文件不存在！","系统提示");
                return;
            }
            try
            {
                Report.LoadReportFromFile(filefullpath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("加载打印模板错误，请联系系统管理员！" + ex.Message, "系统错误");
                return;
            }
            Report.DesignReport();

        }

        private void btn_setuse_Click(object sender, EventArgs e)
        {
            if (dgvm.SelectedRows.Count == 0) return;
            string modename=dgvm.SelectedRows[0].Cells[0].Value.ToString();
            if (MessageBox.Show("是设置当前模板套为在用状态?","系统提示",MessageBoxButtons.YesNo) == DialogResult.No) return;
            Public.SetXmlValue("PrintModuleName", modename);
            listmodule();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgvm.SelectedRows.Count == 0) return;
            string modename = dgvm.SelectedRows[0].Cells[0].Value.ToString();
            if (modename == "标准模板")
            {
                MessageBox.Show("标准模板不允许删除！", "系统提示");
                return;
            }
            if (MessageBox.Show("是设置删除选中的模板套?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            string dirfullpath = Application.StartupPath + "\\report\\" + modename;
            Directory.Delete(dirfullpath, true);
            listmodule();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frminputdirname frm = new frminputdirname();
            frm.ShowDialog();
            string vv = frminputdirname.inputmodename;
            
            if (vv != null&&vv!="")
            {
                string mpath = Application.StartupPath + "\\report\\标准模板";
                if (!Directory.Exists(mpath))
                {
                    MessageBox.Show("标准模板不存在，联系系统管理员！","系统提示");
                    return;
                }
                string fpath = Application.StartupPath + "\\report\\";
                try
                {

                    //创建文件夹
                    Directory.CreateDirectory(fpath + vv);
                    //复制文件

                    DirectoryInfo dir = new DirectoryInfo(mpath);
                    foreach (FileInfo f in dir.GetFiles("*.fr3 "))
                    {
                        string name = f.Name;
                        File.Copy(f.FullName,fpath+vv+"\\"+f.Name);
                    }
                    listmodule();
                    MessageBox.Show("创建成功！","系统提示");
                }
                catch (Exception err)
                {
                    MessageBox.Show("创建失败！"+err.Message,"系统提示");
                }
            }
        }
    }
}