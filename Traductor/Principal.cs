using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydra;
using System.Globalization;
using System.Xml;

namespace Traductor
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        static MakeFba makefba;
       
        
        
        public static Model mod;
        

        public static XmlDocument doc;
        
        
       
        public static bool txt;
        

        
        
        static string fileaddres;
   
        bool issbml;
      
        

        bool yaabri;

       

        public static string FileAddres
        {
            get { return fileaddres; }
            set { fileaddres = value; }
        }
        public static MakeFba Modelo
        {
            get { return makefba; }
            set { makefba = value; }
        }

        string fileopen = "";
        string filesave = "";

        public static Sbml sbml; 

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult ok = openFileDialog1.ShowDialog();

            if (ok == DialogResult.OK)
            {
                Read read = new Read();

                fileopen = openFileDialog1.FileName;

                sbml = read.ReadXml(fileopen);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yaabri = false;
            issbml = false;
            doc = new XmlDocument();
            makefba = new MakeFba();
            sbml = new Sbml();
        }

        private void sbmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openfile.ShowDialog() == DialogResult.OK)
            {
                string aux = openfile.FileName.Split('.')[1];

                if (aux == "xml")
                {


                    fileaddres = openfile.FileName;

                    Read read = new Read();

                    sbml = read.ReadXml(fileaddres);

                    if (sbml.ListReaction.Length == 0 || sbml.ListSpecie.Length == 0)
                    {
                        MessageBox.Show("Unreadable file,\n verify complies with the standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        saveStripButton6.Enabled = true;
                        saveStripMenuItem2.Enabled = true;
                        toolStripButton2.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        savetoolStripButton4.Enabled = true;
                        savetoolStripMenuItem2.Enabled = true;
                        txt = false;
                        issbml = true;
                        if (yaabri)
                        {
                            mod.Close();
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                        }
                        else
                        {
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                            yaabri = true;
                        }
                    }

                    //MessageBox.Show("Successfully Loaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect Extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (yaabri)
            {
                mod.Close();
                yaabri = false;
                toolStripButton2.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                saveStripButton6.Enabled = false;
                saveStripMenuItem2.Enabled = false;
                savetoolStripButton4.Enabled = false;
                savetoolStripMenuItem2.Enabled = false;
                toolStripButton2.Enabled = false;

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (yaabri)
            {
                mod.Close();
                yaabri = false;
                toolStripButton2.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                saveStripButton6.Enabled = false;
                saveStripMenuItem2.Enabled = false;
                savetoolStripButton4.Enabled = false;
                savetoolStripMenuItem2.Enabled = false;
                toolStripButton2.Enabled = false;

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.openfile.ShowDialog() == DialogResult.OK)
            {
                string aux = openfile.FileName.Split('.')[1];

                if (aux == "xml")
                {
                    

                    fileaddres = openfile.FileName;

                    Read read = new Read();

                    sbml = read.ReadXml(fileaddres);

                    if (sbml.ListReaction.Length == 0 || sbml.ListSpecie.Length == 0)
                    {
                        MessageBox.Show("Unreadable file,\n verify complies with the standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        saveStripButton6.Enabled = true;
                        saveStripMenuItem2.Enabled = true;
                        toolStripButton2.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        savetoolStripButton4.Enabled = true;
                        savetoolStripMenuItem2.Enabled = true;
                        txt = false;
                        issbml = true;
                        doc.Load(fileaddres);
                        if (yaabri)
                        {
                            mod.Close();
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                        }
                        else
                        {
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                            yaabri = true;
                        }
                    }
                    
                    //MessageBox.Show("Successfully Loaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect Extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void saveStripButton6_Click(object sender, EventArgs e)
        {
            if (issbml)
            {
                DialogResult ok = saveFileDialog1.ShowDialog();

                if (ok == DialogResult.OK)
                {
                    Read read = new Read();

                    

                    filesave = saveFileDialog1.FileName;

                    SbmlTraductor trs = new SbmlTraductor(sbml);

                    trs.SbmlToTxt(filesave);

                    MessageBox.Show("Successfully saved!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else 
            {
                DialogResult ok = saveFileDialog2.ShowDialog();

                if (ok == DialogResult.OK)
                {
                    Read read = new Read();

                   

                    filesave = saveFileDialog2.FileName;

                    SbmlTraductor trs = new SbmlTraductor(sbml);

                    trs.TxtToSbml(filesave);

                    MessageBox.Show("Successfully saved!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.openfile2.ShowDialog() == DialogResult.OK)
            {
                string aux = openfile2.FileName.Split('.')[1];

                if (aux == "txt")
                {

                    fileaddres = openfile2.FileName;
                    Read read = new Read();

                    sbml = read.Readtxt(fileaddres);

                    if (sbml.ListReaction.Length == 0 || sbml.ListSpecie.Length == 0)
                    {
                        MessageBox.Show("Unreadable file,\n verify complies with the standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        saveStripButton6.Enabled = true;
                        saveStripMenuItem2.Enabled = true;
                        toolStripButton2.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        savetoolStripMenuItem2.Enabled = true;
                        savetoolStripButton4.Enabled = true;

                        txt = true;
                        issbml = false;
                        if (yaabri)
                        {
                            mod.Close();
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                        }
                        else
                        {
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                            yaabri = true;
                        }
                    }
                   
                    
                }
                else
                {
                    MessageBox.Show("Incorrect Extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
      
        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openfile2.ShowDialog() == DialogResult.OK)
            {
                string aux = openfile2.FileName.Split('.')[1];

                if (aux == "txt")
                {

                    fileaddres = openfile2.FileName;
                    Read read = new Read();

                    sbml = read.Readtxt(fileaddres);

                    if (sbml.ListReaction.Length == 0 || sbml.ListSpecie.Length == 0)
                    {
                        MessageBox.Show("Unreadable file,\n verify complies with the standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        saveStripButton6.Enabled = true;
                        saveStripMenuItem2.Enabled = true;
                        toolStripButton2.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        savetoolStripMenuItem2.Enabled = true;
                        savetoolStripButton4.Enabled = true;
                        doc.Load(fileaddres);
                        txt = true;
                        issbml = false;
                        if (yaabri)
                        {
                            mod.Close();
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                        }
                        else
                        {
                            mod = new Model();
                            mod.MdiParent = this;
                            mod.Show();
                            yaabri = true;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Incorrect Extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void saveStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void savetoolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Principal.txt)
                {
                    DialogResult ok = saveFileDialog2.ShowDialog();

                    if (ok == DialogResult.OK)
                    {
                        Principal.doc.Save(saveFileDialog2.FileName);

                        MessageBox.Show("Successfully saved!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (Principal.txt)
                    {
                        DialogResult ok = saveFileDialog1.ShowDialog();

                        if (ok == DialogResult.OK)
                        {
                            SbmlTraductor trad = new SbmlTraductor(sbml);
                            trad.SbmlToTxt(saveFileDialog1.FileName);
                            MessageBox.Show("Successfully saved!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void savetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!Principal.txt)
            {
                DialogResult ok = saveFileDialog2.ShowDialog();

                if (ok == DialogResult.OK)
                {
                    Principal.doc.Save(saveFileDialog2.FileName);

                    MessageBox.Show("Successfully saved!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (Principal.txt)
                {
                    DialogResult ok = saveFileDialog1.ShowDialog();

                    if (ok == DialogResult.OK)
                    {
                        SbmlTraductor trad = new SbmlTraductor(sbml);
                        trad.SbmlToTxt(saveFileDialog1.FileName);
                        MessageBox.Show("Successfully saved!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

    }
}
