using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem_2_Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
              string src_folder = "C:\\Users\\sinanant\\C_sharp\\Sheet Problem\\Problem_2_Multithreading\\Src_Folder";
               string main_folder = "C:\\Users\\sinanant\\C_sharp\\Sheet Problem\\Problem_2_Multithreading\\Folder";
               //string file_path= @"C:\Users\sinanant\C_sharp\Sheet Problem\Problem_2_Multithreading\file.txt";
               string dst_txt = "C:\\Users\\sinanant\\C_sharp\\Sheet Problem\\Problem_2_Multithreading\\Folder\\Txt";
               string dst_image = "C:\\Users\\sinanant\\C_sharp\\Sheet Problem\\Problem_2_Multithreading\\Folder\\Image";
               Thread Move_File = new Thread(() =>Move_file(src_folder,dst_txt,dst_image));
               Thread Delete_File=new Thread(()=>Delete(main_folder));
               
                Move_File.Start();
                Delete_File.Start();

                Move_File.Join();
                Delete_File.Join();


        }

        public static void Delete(string  main_folder)
        {

            //string[] files=Directory.GetFiles(main_folder);
            string[] files = Directory.GetFiles(main_folder, "*.*", SearchOption.AllDirectories);

            Parallel.ForEach(files, (file) =>
            {
                if (File.Exists(file))
                {
                    FileInfo fileInfo = new FileInfo(file);
                     //Console.WriteLine("File_name={0}",fileInfo.FullName);

                    long fileSize = fileInfo.Length;

                    //Console.WriteLine("File_size={0}", fileSize);
                    
                    string file_extension = Path.GetExtension(file).ToLower();

                    if (file_extension == ".txt" && fileSize > 5120)
                    {
                        
                        File.Delete(file);
                        Console.WriteLine("File is deleted successfully");
                    }

                    else if (file_extension == ".png" && fileSize > 102400 ||
                       file_extension == ".jpeg" && fileSize > 102400)
                    {
                        File.Delete(file);
                        Console.WriteLine("File is deleted successfully");
                    }


                }
                else
                {
                    Console.WriteLine("File does not exist");
                }

            });

          
        }
        public static void Move_file( string  src_folder,string dst_txt,string dst_image)
        {

            string[] files = Directory.GetFiles(src_folder);
            if (files.Length == 0)
            {
                Console.WriteLine("Folder is empty");
            }
            else
            {


                Parallel.ForEach(files, (file) =>
                {




                    if (File.Exists(file))
                    {
                        string file_extension = Path.GetExtension(file).ToLower();
                        string file_name = Path.GetFileName(file);

                        string dst_folder = string.Empty;


                        if (file_extension == ".txt")
                        {
                            dst_folder = dst_txt;
                        }
                        else if (file_extension == ".png" || file_extension == ".jpeg")
                        {
                            dst_folder = dst_image;
                        }


                        if (!string.IsNullOrEmpty(dst_folder))
                        {
                            //if (!Directory.Exists(dst_folder))
                            //{
                            //    Directory.CreateDirectory(dst_folder);
                            //}

                            string dst_file_path = Path.Combine(dst_folder, file_name);
                            File.Move(file, dst_file_path);
                            Console.WriteLine($"File moved to dst_path {dst_file_path}");
                        }
                        else
                        {
                            Console.WriteLine("Error in handling");
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                });
            }

           
           
        }
    }

  
}