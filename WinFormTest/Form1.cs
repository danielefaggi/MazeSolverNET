﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormTest
{
    public partial class Form1 : Form
    {
        private int mRows;
        private int mCols;
        private FieldGrid mFieldGrid;

        private int mSquareSizeX = 10;
        private int mSquareSizeY = 10;

        private FieldElement mFillElement = FieldElement.Empty;

        private MazeSolver mSolver = null;

        public Form1()
        {

            InitializeComponent();

            mRows = 10;
            mCols = 10;

            mFieldGrid = new FieldGrid(mRows, mCols);

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if (mFieldGrid.Cols != mCols) mFieldGrid.Cols = mCols;
            if (mFieldGrid.Rows != mRows) mFieldGrid.Rows = mRows;

            panGrid.Width = mSquareSizeX * mFieldGrid.Cols + 1;
            panGrid.Height = mSquareSizeY * mFieldGrid.Rows + 1;

            panGrid.Invalidate();
        }

        private void txtCols_Enter(object sender, EventArgs e)
        {
            txtCols.Text = mCols.ToString();
        }

        private void txtCols_Leave(object sender, EventArgs e)
        {
            int n = 0;

            if (!int.TryParse(txtCols.Text, out n))
            {
                txtCols.Text = mCols.ToString();
            }
            else
            {
                mCols = n;
                txtCols.Text = mCols.ToString();

                UpdateGrid();
            }
        }

        private void txtRows_Enter(object sender, EventArgs e)
        {
            txtRows.Text = mRows.ToString();
        }

        private void txtRows_Leave(object sender, EventArgs e)
        {
            int n = 0;

            if (!int.TryParse(txtRows.Text, out n))
            {
                txtRows.Text = mRows.ToString();
            }
            else
            {
                mRows = n;
                txtRows.Text = mRows.ToString();

                UpdateGrid();
            }

        }

        private void panGrid_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            for (int r = 1; r < mFieldGrid.Rows; r++)
            {
                gr.DrawLine(SystemPens.GrayText, 0, r * mSquareSizeY, panGrid.Width, r * mSquareSizeY);
            }

            for (int c = 1; c < mFieldGrid.Cols; c++)
            {
                gr.DrawLine(SystemPens.GrayText, c * mSquareSizeX, 0, c * mSquareSizeX, panGrid.Height);
            }


            for (int r = 0; r < mFieldGrid.Rows; r++)
            {
                for (int c = 0; c < mFieldGrid.Cols; c++)
                {
                    if (mFieldGrid.GetCell(r, c) == FieldElement.Wall)
                    {
                        gr.FillRectangle(Brushes.Gray, c * mSquareSizeX, r * mSquareSizeY,
                                                        mSquareSizeX, mSquareSizeY);
                    }
                    else if (mFieldGrid.GetCell(r, c) == FieldElement.Start)
                    {
                        gr.FillRectangle(Brushes.Green, c * mSquareSizeX, r * mSquareSizeY,
                                mSquareSizeX, mSquareSizeY);
                    }
                    else if (mFieldGrid.GetCell(r, c) == FieldElement.Finish)
                    {
                        gr.FillRectangle(Brushes.Red, c * mSquareSizeX, r * mSquareSizeY,
                                mSquareSizeX, mSquareSizeY);
                    }
                }
            }


            if (mSolver != null)
            {
                if (mSolver.mSolutions.Count > 0)
                {
                    foreach (FieldCoord coord in mSolver.mSolutions[0])
                    {
                        if (mFieldGrid.GetCell(coord.Row, coord.Col) == FieldElement.Empty)
                        {
                            gr.FillRectangle(Brushes.Yellow, coord.Col * mSquareSizeX, coord.Row * mSquareSizeY,
                                    mSquareSizeX, mSquareSizeY);
                        }
                    }
                }
            }
        }

        private void panGrid_MouseDown(object sender, MouseEventArgs e)
        {
            int r = e.Y / mSquareSizeY;
            int c = e.X / mSquareSizeX;

            if (r < mFieldGrid.Rows && c < mFieldGrid.Cols)
            {
                if (radWall.Checked)
                {
                    if (mFieldGrid.GetCell(r, c) == FieldElement.Empty)
                    {
                        mFieldGrid.SetCell(r, c, FieldElement.Wall);
                        mFillElement = FieldElement.Wall;
                    }
                    else
                    {
                        mFieldGrid.SetCell(r, c, FieldElement.Empty);
                        mFillElement = FieldElement.Empty;
                    }
                }
                else if (radStart.Checked)
                {
                    mFieldGrid.ClearCells(FieldElement.Start);
                    mFieldGrid.SetCell(r, c, FieldElement.Start);
                }
                else if (radFinish.Checked)
                {
                    mFieldGrid.ClearCells(FieldElement.Finish);
                    mFieldGrid.SetCell(r, c, FieldElement.Finish);
                }

                panGrid.Invalidate();
            }
        }

        private void panGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int r = e.Y / mSquareSizeY;
                int c = e.X / mSquareSizeX;

                if (r < mFieldGrid.Rows && c < mFieldGrid.Cols)
                {
                    mFieldGrid.SetCell(r, c, mFillElement);
                    panGrid.Invalidate();

                }

            }
        }

        private void butGo_Click(object sender, EventArgs e)
        {
            mSolver = new MazeSolver(mFieldGrid);

            mSolver.Solve();

            panGrid.Invalidate();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save maze definition file";
                sfd.Filter = "Maze file (*.maze)|*.maze";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine("Maze 1.0");
                        sw.WriteLine(mFieldGrid.Rows.ToString());
                        sw.WriteLine(mFieldGrid.Cols.ToString());

                        int i = 1;
                        for (int r = 0; r < mFieldGrid.Rows; r++)
                        {
                            for (int c = 0; c < mFieldGrid.Cols; c++)
                            {
                                byte val = 0;
                                FieldElement elem = mFieldGrid.GetCell(r, c);
                                if (elem == FieldElement.Wall)
                                {
                                    val = 1;
                                }
                                else if (elem == FieldElement.Start)
                                {
                                    val = 2;
                                }
                                else if (elem == FieldElement.Finish)
                                {
                                    val = 3;
                                }
                                sw.Write(val);
                                if (++i >= 40)
                                {
                                    i = 1;
                                    sw.WriteLine();
                                }
                            }
                        }

                        sw.Close();
                    }
                }
            }
        }

        private void butLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Load maze definition file";
                ofd.Filter = "Maze file (*.maze)|*.maze";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        String line;

                        line = sr.ReadLine();
                        if (!line.Equals("Maze 1.0"))
                        {
                            sr.Close();
                            return;
                        }

                        int rows = 0;
                        line = sr.ReadLine();
                        if (!int.TryParse(line, out rows))
                        {
                            sr.Close();
                            return;
                        }

                        int cols = 0;
                        line = sr.ReadLine();
                        if (!int.TryParse(line, out cols))
                        {
                            sr.Close();
                            return;
                        }
                        
                        mFieldGrid.Rows = rows;
                        mFieldGrid.Cols = cols;

                        mRows = rows;
                        mCols = cols;
                        txtRows.Text = mRows.ToString();
                        txtCols.Text = mCols.ToString();

                        UpdateGrid();

                        line = sr.ReadLine();
                        int i = 0;
                        for (int r = 0; r < mFieldGrid.Rows; r++)
                        {
                            for (int c = 0; c < mFieldGrid.Cols; c++)
                            {
                                byte val = 0;
                                byte.TryParse(line.Substring(i, 1), out val);

                                if(val == 1)
                                {
                                    mFieldGrid.SetCell(r, c, FieldElement.Wall);
                                }
                                else if(val == 2)
                                {
                                    mFieldGrid.SetCell(r, c, FieldElement.Start);
                                }
                                else if(val == 3)
                                {
                                    mFieldGrid.SetCell(r, c, FieldElement.Finish);
                                }
                                else
                                {
                                    mFieldGrid.SetCell(r, c, FieldElement.Empty);
                                }

                                if(++i >= line.Length)
                                {
                                    line = sr.ReadLine();
                                    i = 0;
                                }
                            }
                        }

                        sr.Close();
                    }
                }
            }

            panGrid.Invalidate();
        }
    }
}
