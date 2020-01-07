using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSafaryC
{
    
    public partial class medium : Form
    {
        //T = Teman(team biru)
        //M = musuh(team merah)
        //R = Rumput
        //A = Air
        //FM = finish merah(kotak biru)
        //FT = finish biru(kotak merah)
        //TT = trap biru
        //TM = trap merah
        Random random;
        int randomhewan;
        int randomarah;
        String[,] map = new String[9, 7];
        List<trap> listfinish = new List<trap>();
        List<trap> listtrap = new List<trap>();
        List<animal> listanimal = new List<animal>();
        int counter = 1;
        int indexterambil = -1;
        String turn = "T";

        public medium()
        {
            InitializeComponent();
            buat();
            refreshmap();
            Invalidate();
            refreshstatus();
        }
        public void buat()
        {
            listtrap.Add(new trap(2, 0, "M"));
            listtrap.Add(new trap(4, 0, "M"));
            listtrap.Add(new trap(3, 1, "M"));
            listtrap.Add(new trap(2, 8, "T"));
            listtrap.Add(new trap(4, 8, "T"));
            listtrap.Add(new trap(3, 7, "T"));

            listanimal.Add(new animal(0, 0, 2, "M"));
            listanimal.Add(new animal(0, 2, 8, "M"));
            listanimal.Add(new animal(1, 1, 6, "M"));
            listanimal.Add(new animal(2, 2, 4, "M"));
            listanimal.Add(new animal(6, 0, 3, "M"));
            listanimal.Add(new animal(5, 1, 7, "M"));
            listanimal.Add(new animal(4, 2, 5, "M"));
            listanimal.Add(new animal(6, 2, 1, "M"));

            listanimal.Add(new animal(0, 6, 1, "T"));
            listanimal.Add(new animal(0, 8, 3, "T"));
            listanimal.Add(new animal(1, 7, 7, "T"));
            listanimal.Add(new animal(2, 6, 5, "T"));
            listanimal.Add(new animal(4, 6, 4, "T"));
            listanimal.Add(new animal(6, 6, 8, "T"));
            listanimal.Add(new animal(5, 7, 6, "T"));
            listanimal.Add(new animal(6, 8, 2, "T"));

            listfinish.Add(new trap(3, 0, "T"));
            listfinish.Add(new trap(3, 8, "M"));
        }
        //refresh map setiap selesai onclick bergerak
        public void refreshmap()
        {
            //isi map dengan rumput dan air saja
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i > 2 && i < 6)
                    {
                        if (j > 0 && j < 3 || j > 3 && j < 6)
                        {
                            map[i, j] = "A";
                        }
                        else
                        {
                            map[i, j] = "R";
                        }
                    }
                    else
                    {
                        map[i, j] = "R";
                    }
                }
            }
            //mengisi map dengan trap
            for (int i = 0; i < listtrap.Count; i++)
            {
                if (listtrap[i].pemilik == "T")
                {
                    map[listtrap[i].y, listtrap[i].x] = "TT";
                }
                if (listtrap[i].pemilik == "M")
                {
                    map[listtrap[i].y, listtrap[i].x] = "TM";
                }

            }
            //mengisi map dengan finish
            for (int i = 0; i < listfinish.Count; i++)
            {
                map[listfinish[i].y, listfinish[i].x] = "F" + listfinish[i].pemilik;
            }
            //mengisi map dengan binatang
            for (int i = 0; i < listanimal.Count; i++)
            {
                map[listanimal[i].y, listanimal[i].x] = listanimal[i].pemilik + listanimal[i].power.ToString();
            }
        }
        Graphics g;
        //cek kondisi win habis atau tidaknya merah atau biru
        public void cekwin()
        {
            bool biru = false;
            bool merah = false;
            for (int i = 0; i < listanimal.Count; i++)
            {
                if (listanimal[i].pemilik == "T")
                {
                    biru = true;
                }
                else
                {
                    merah = true;
                }
            }
            if (biru == false)
            {
                MessageBox.Show("Red Team WIN");
            }
            if (merah == false)
            {
                MessageBox.Show("Blue Team WIN");
            }
        }
        //get resource image
        public Image getImage(String apa)
        {
            if (apa == "R")
            {
                return Image.FromFile("rumput.PNG");
            }
            else if (apa == "A")
            {
                return Image.FromFile("air.PNG");
            }
            else if (apa == "TT" || apa == "TM")
            {
                return Image.FromFile("trap.PNG");
            }
            else if (apa == "FM")
            {
                return Image.FromFile("goalBiru.PNG");
            }
            else if (apa == "FT")
            {
                return Image.FromFile("goalMerah.PNG");
            }
            else
            {
                return Image.FromFile(apa + ".PNG");
            }

        }
        //mengganti turn dan status player bermain
        public void refreshstatus()
        {
            if (counter == 1)
            {
                txtstatus.Text = "sedang memilih hewan";
            }
            else
            {
                txtstatus.Text = "sedang memilih arah gerak";
            }
            if (turn == "T")
            {
                txtgiliran.Text = "team biru";
            }
            else
            {
                txtgiliran.Text = "team merah";
            }
        }

        //cek gerak valid atau tidak
        public bool isValidMove(int y, int x)
        {
            random = new Random();
            randomhewan = random.Next(0, 8);
            randomarah = random.Next(0, 3);

            //cari selisih x dan selisih y dari pergerakan player
            bool kembalian = false;
            int selisih_x = listanimal[indexterambil].x - x;
            int selisih_y = listanimal[indexterambil].y - y;
            // cek apakah x atau y terdapat salah satu sejajar karna player tidak dapat bergerak miring
            if (listanimal[indexterambil].x == x || listanimal[indexterambil].y == y)
            {
                //jika selisih 1 maka player hanya bergerak 1 langkah
                if (selisih_x == 1 || selisih_y == 1 || selisih_x == -1 || selisih_y == -1)
                {
                    //cek langkah yang dituju player rumput,trap,air,atau musuh yang didarat dan diair dan juga cek win
                    if (map[y, x] == "R" || map[y, x] == "TT" || map[y, x] == "TM")
                    {
                        listanimal[indexterambil].x = x;
                        listanimal[indexterambil].y = y;
                        listanimal[indexterambil].dalamair = false;

                        if (map[y, x] == "TT" && listanimal[randomhewan].pemilik == "M")
                        {
                            listanimal[randomhewan].x = x;
                            listanimal[randomarah].y = y;
                            listanimal[randomhewan].dalamair = false;
                            listanimal[randomhewan].dalamtrap = true;
                        }
                        else if (map[y, x] == "TM" && listanimal[indexterambil].pemilik == "T")
                        {
                            
                            listanimal[indexterambil].dalamtrap = true;
                        }
                        else
                        {
                          
                            listanimal[randomarah].dalamtrap = false;
                        }
                        kembalian = true;
                    }
                    else if (map[y, x] == "A" && listanimal[indexterambil].power == 8 && listanimal[indexterambil].pemilik == "T")
                    {
                        listanimal[indexterambil].x = x;
                        listanimal[indexterambil].y = y;
                        listanimal[indexterambil].dalamair = true;
                        listanimal[indexterambil].dalamtrap = false;
                        kembalian = true;
                    }
                    else if (map[y, x] == "FT" && listanimal[indexterambil].pemilik == "T")
                    {
                        MessageBox.Show("Blue Team WIN");
                        int jumawal = 8;
                        int hitung = 0;
                        for (int i = 0; i < listanimal.Count; i++)
                        {
                            if (listanimal[i].pemilik == "M")
                            {
                                hitung++;
                            }
                        }
                        jumawal -= hitung;
                        form_win f = new form_win("BIRU", "GOAL", jumawal + "");
                        f.Visible = true;
                        this.Close();
                        listanimal[indexterambil].x = x;
                        listanimal[indexterambil].y = y;
                        listanimal[indexterambil].dalamair = false;
                        listanimal[indexterambil].dalamtrap = false;
                        kembalian = true;
                    }
                    else if (map[y, x] == "FM" && listanimal[randomhewan].pemilik == "M")
                    {
                        MessageBox.Show("Red Team WIN");
                        int jumawal = 8;
                        int hitung = 0;
                        for (int i = 0; i < listanimal.Count; i++)
                        {
                            if (listanimal[i].pemilik == "T")
                            {
                                hitung++;
                            }
                        }
                        jumawal -= hitung;
                        form_win f = new form_win("MERAH", "GOAL", jumawal + "");
                        f.Visible = true;
                        this.Close();
                        listanimal[randomhewan].x = x;
                        listanimal[randomarah].y = y;
                        listanimal[randomhewan].dalamair = false;
                        listanimal[randomhewan].dalamtrap = false;
                        kembalian = true;
                    }
                    else
                    {
                        for (int i = 0; i < listanimal.Count; i++)
                        {
                            if (listanimal[i].y == y && listanimal[i].x == x && listanimal[i].pemilik != turn)
                            {
                                if (listanimal[randomhewan].power == 8 && listanimal[i].power == 1 && listanimal[i].dalamair == false)
                                {
                                    listanimal[randomhewan].x = x;
                                    listanimal[randomarah].y = y;
                                    listanimal.RemoveAt(i);
                                    kembalian = true;
                                }
                                else if (listanimal[randomhewan].power <= listanimal[i].power && listanimal[i].dalamair == false && listanimal[randomhewan].dalamair == false)
                                {
                                    if (listanimal[randomhewan].power == 1 && listanimal[i].power == 8)
                                    {
                                        kembalian = false;
                                        lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                    }
                                    else
                                    {
                                        listanimal[randomhewan].x = x;
                                        listanimal[randomarah].y = y;
                                        listanimal.RemoveAt(i);
                                        kembalian = true;
                                    }
                                }
                                else if (listanimal[randomhewan].power == 8 && listanimal[i].power == 8)
                                {
                                    listanimal[randomhewan].x = x;
                                    listanimal[randomarah].y = y;
                                    listanimal.RemoveAt(i);
                                    kembalian = true;
                                }
                                else if (listanimal[i].dalamtrap == true)
                                {
                                    listanimal[randomhewan].x = x;
                                    listanimal[randomarah].y = y;
                                    listanimal.RemoveAt(i);
                                    kembalian = true;
                                }
                                else
                                {
                                    kembalian = false;
                                    lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                }
                            }
                        }
                    }
                }
                //cek jika player bergerak 2 langkah
                else if ((selisih_x == 3 || selisih_x == -3) && (listanimal[randomhewan].power == 2 || listanimal[randomhewan].power == 3))
                {
                    //cek player bergerak ke kiri atau ke kanan dan cek langkah player ke depan
                    if (selisih_x > 0)
                    {
                        String a = map[listanimal[randomarah].y, listanimal[randomhewan].x - 1];
                        String b = map[listanimal[randomarah].y, listanimal[randomhewan].x - 2];
                        String c = map[listanimal[randomarah].y, listanimal[randomhewan].x - 3];
                        if (a == "A" && b == "A")
                        {
                            if (c == "R")
                            {
                                kembalian = true;
                                listanimal[randomhewan].x = x;
                                listanimal[randomarah].y = y;
                            }
                            else
                            {
                                int indexdiseberang = -1;
                                for (int i = 0; i < listanimal.Count; i++)
                                {
                                    if (listanimal[i].y == listanimal[randomarah].y && listanimal[i].x == listanimal[randomhewan].x - 3)
                                    {
                                        indexdiseberang = i;
                                    }
                                }
                                if (listanimal[indexdiseberang].pemilik != listanimal[randomhewan].pemilik)
                                {
                                    if (listanimal[randomhewan].power <= listanimal[indexdiseberang].power)
                                    {
                                        listanimal[randomhewan].x = x;
                                        listanimal[randomarah].y = y;
                                        listanimal.RemoveAt(indexdiseberang);
                                        kembalian = true;
                                    }
                                    else
                                    {
                                        kembalian = false;
                                        lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                    }
                                }
                                else
                                {
                                    kembalian = false;
                                    lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                }
                            }
                        }
                        else
                        {
                            kembalian = false;
                            lbfalse.Text = "tidak dapat melewati tikus di air";
                        }
                    }
                    else
                    {
                        String a = map[listanimal[randomarah].y, listanimal[randomhewan].x + 1];
                        String b = map[listanimal[randomarah].y, listanimal[randomhewan].x + 2];
                        String c = map[listanimal[randomarah].y, listanimal[randomhewan].x + 3];
                        if (a == "A" && b == "A")
                        {
                            if (c == "R")
                            {
                                listanimal[randomhewan].x = x;
                                listanimal[randomarah].y = y;
                                kembalian = true;
                            }
                            else
                            {
                                int indexdiseberang = -1;
                                for (int i = 0; i < listanimal.Count; i++)
                                {
                                    if (listanimal[i].y == listanimal[randomarah].y && listanimal[i].x == listanimal[randomhewan].x + 3)
                                    {
                                        indexdiseberang = i;
                                    }
                                }
                                if (listanimal[indexdiseberang].pemilik != listanimal[randomhewan].pemilik)
                                {
                                    if (listanimal[randomhewan].power <= listanimal[indexdiseberang].power)
                                    {
                                        listanimal[randomhewan].x = x;
                                        listanimal[randomarah].y = y;
                                        listanimal.RemoveAt(indexdiseberang);
                                        kembalian = true;
                                    }
                                    else
                                    {
                                        kembalian = false;
                                        lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                    }
                                }
                                else
                                {
                                    kembalian = false;
                                    lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                }
                            }
                        }
                        else
                        {
                            kembalian = false;
                            lbfalse.Text = "tidak dapat melewati tikus di air";
                        }
                    }
                }
                //cek jika player bergerak 3 langkah
                else if ((selisih_y == 4 || selisih_y == -4) && (listanimal[randomhewan].power == 2 || listanimal[randomhewan].power == 3))
                {
                    //cek player bergerak ke bawah atau ke atas dan cek langkah player ke depan
                    if (selisih_y > 0)
                    {
                        String a = map[listanimal[randomarah].y - 1, listanimal[randomhewan].x];
                        String b = map[listanimal[randomarah].y - 2, listanimal[randomhewan].x];
                        String c = map[listanimal[randomarah].y - 3, listanimal[randomhewan].x];
                        String d = map[listanimal[randomarah].y - 4, listanimal[randomhewan].x];
                        if (a == "A" && b == "A" && c == "A")
                        {
                            if (d == "R")
                            {
                                listanimal[randomhewan].x = x;
                                listanimal[randomarah].y = y;
                                kembalian = true;
                            }
                            else
                            {
                                int indexdiseberang = -1;
                                for (int i = 0; i < listanimal.Count; i++)
                                {
                                    if (listanimal[i].y == listanimal[randomarah].y - 4 && listanimal[i].x == listanimal[randomhewan].x)
                                    {
                                        indexdiseberang = i;
                                    }
                                }
                                if (listanimal[indexdiseberang].pemilik != listanimal[randomhewan].pemilik)
                                {
                                    if (listanimal[randomhewan].power <= listanimal[indexdiseberang].power)
                                    {
                                        listanimal[indexterambil].x = x;
                                        listanimal[indexterambil].y = y;
                                        listanimal.RemoveAt(indexdiseberang);
                                        kembalian = true;
                                    }
                                    else
                                    {
                                        kembalian = false;
                                        lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                    }
                                }
                                else
                                {
                                    kembalian = false;
                                    lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                }
                            }
                        }
                        else
                        {
                            kembalian = false;
                            lbfalse.Text = "tidak dapat melewati tikus di air";
                        }
                    }
                    if (selisih_y < 0)
                    {
                        String a = map[listanimal[randomarah].y + 1, listanimal[randomhewan].x];
                        String b = map[listanimal[randomarah].y + 2, listanimal[randomhewan].x];
                        String c = map[listanimal[randomarah].y + 3, listanimal[randomhewan].x];
                        String d = map[listanimal[randomarah].y + 4, listanimal[randomhewan].x];
                        if (a == "A" && b == "A" && c == "A")
                        {
                            if (d == "R")
                            {
                                listanimal[randomhewan].x = x;
                                listanimal[randomarah].y = y;
                                kembalian = true;
                            }
                            else
                            {
                                int indexdiseberang = -1;
                                for (int i = 0; i < listanimal.Count; i++)
                                {
                                    if (listanimal[i].y == listanimal[randomarah].y + 4 && listanimal[i].x == listanimal[randomhewan].x)
                                    {
                                        indexdiseberang = i;
                                    }
                                }
                                if (listanimal[indexdiseberang].pemilik != listanimal[randomhewan].pemilik)
                                {
                                    if (listanimal[randomhewan].power <= listanimal[indexdiseberang].power)
                                    {
                                        listanimal[randomhewan].x = x;
                                        listanimal[randomarah].y = y;
                                        listanimal.RemoveAt(indexdiseberang);
                                        kembalian = true;
                                    }
                                    else
                                    {
                                        kembalian = false;
                                        lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                    }
                                }
                                else
                                {
                                    kembalian = false;
                                    lbfalse.Text = "hewan yang ingin dimakan tidak valid";
                                }
                            }
                        }
                        else
                        {
                            kembalian = false;
                            lbfalse.Text = "tidak dapat melewati tikus di air";
                        }
                    }
                }
                else
                {
                    kembalian = false;
                    lbfalse.Text = "langkah tidak benar";
                }
            }
            else
            {
                kembalian = false;
                lbfalse.Text = "langkah tidak benar";
            }
            return kembalian;
        }
        //ganti turn player
        public void gantiturn()
        {
            if (turn == "T")
            {
                turn = "M";
            }
            else
            {
                turn = "T";
            }
        }
        //private int gerak_ai(int kedalaman, state state, int alpha, int beta)
        //{
        //    if (kedalaman >= ply || state.cek_menang() == true)
        //    {
        //        return state.hitung_sbe(hewan_value, hewan_map_value);
        //    }
        //    else
        //    {
        //        if (kedalaman % 2 == 0) //giliran ai
        //        {
        //            int batas_bawah = -99999;
        //            for (int i = 7; i >= 0; i--)
        //            {
        //                for (int j = 0; j < 8; j++)
        //                {
        //                    state clone = new state(state);
        //                    if (clone.list_hewan_player2.get(i).status_hidup == true && clone.cek_valid_gerakkan_hewan_ke(clone.list_hewan_player2.get(i), clone.list_hewan_player2.get(i).x + arr_gerak_x[j], clone.list_hewan_player2.get(i).y + arr_gerak_y[j], terrain))
        //                    {
        //                        //jika valid backtrack
        //                        Integer pointer = new Integer(kedalaman + 1);
        //                        clone.gerakkan_hewan_ke(clone.list_hewan_player2.get(i), clone.list_hewan_player2.get(i).x + arr_gerak_x[j], clone.list_hewan_player2.get(i).y + arr_gerak_y[j], terrain);

        //                        //simpan sbe hasil backtrack untuk dibandingkan
        //                        int temp = gerak_ai(pointer, clone, alpha, beta);

        //                        if (batas_bawah < temp)
        //                        {
        //                            if (kedalaman == 0)
        //                            {
        //                                simpan_hewan = i;
        //                                simpan_gerak = j;
        //                            }
        //                            batas_bawah = temp;
        //                        }

        //                        if (alpha < batas_bawah)
        //                        {
        //                            alpha = batas_bawah;
        //                        }

        //                        if (beta <= alpha)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                }
        //            }

        //            return batas_bawah;
        //        }
        //        else //giliran player
        //        {
        //            int batas_atas = 99999;

        //            for (int i = 7; i >= 0; i--)
        //            {
        //                for (int j = 0; j < 8; j++)
        //                {
        //                    state clone = new state(state);

        //                    if (clone.list_hewan_player1.get(i).status_hidup == true && clone.cek_valid_gerakkan_hewan_ke(clone.list_hewan_player1.get(i), clone.list_hewan_player1.get(i).x + arr_gerak_x[j], clone.list_hewan_player1.get(i).y + arr_gerak_y[j], terrain))
        //                    {
        //                        //jika valid backtrack
        //                        Integer pointer = new Integer(kedalaman + 1);
        //                        clone.gerakkan_hewan_ke(clone.list_hewan_player1.get(i), clone.list_hewan_player1.get(i).x + arr_gerak_x[j], clone.list_hewan_player1.get(i).y + arr_gerak_y[j], terrain);

        //                        //simpan sbe hasil backtrack untuk dibandingkan
        //                        int temp = gerak_ai(pointer, clone, alpha, beta);

        //                        if (batas_atas > temp)
        //                        {
        //                            batas_atas = temp;
        //                        }

        //                        if (beta > batas_atas)
        //                        {
        //                            beta = batas_atas;
        //                        }

        //                        if (beta <= alpha)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                }
        //            }

        //            return batas_atas;
        //        }
        //    }
        //}
        private void medium_MouseClick(object sender, MouseEventArgs e)
        {
            //cek tabrakan mouse dengan graphics
            Rectangle mouse = new Rectangle(e.X, e.Y, 5, 5);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Rectangle ball = new Rectangle(j * 50, i * 50, 40, 40);
                    if (ball.IntersectsWith(mouse))
                    {
                        //counter = 1 berarti player belum memilih hewan
                        //counter = 2 berarti player sudah memilih hewan dan mencari posisi hewan bergerak
                        if (counter == 1)
                        {
                            //cek hewan yang dipencet dan juga pemiliknya
                            for (int k = 0; k < listanimal.Count; k++)
                            {
                                if (listanimal[k].x == j && listanimal[k].y == i && listanimal[k].pemilik == turn)
                                {
                                    counter++;
                                    indexterambil = k;
                                }
                            }
                        }
                        else if (counter == 2)
                        {
                            //cek gerakan valid atau tidak jika kembalian true valid move jika false tidak masuk if
                            if (isValidMove(i, j))
                            {
                                //jika valid refresh array map dengan yang baru dan gambar ulang serta cek 
                                //pion musuh atau team habis atau tidak serta ganti turn
                                refreshmap();
                                Invalidate();
                                cekwin();
                                gantiturn();
                                lbfalse.Text = "";
                            }
                            counter = 1;
                            indexterambil = -1;
                        }
                    }
                }
            }
            refreshstatus();
        }

        private void medium_Paint(object sender, PaintEventArgs e)
        {
            //menggambar mapnya
            g = this.CreateGraphics();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    e.Graphics.DrawImage(getImage(map[i, j]), j * 50, i * 50, 40, 40);
                }
            }
        }

        private void medium_Load(object sender, EventArgs e)
        {

        }
    }
}
