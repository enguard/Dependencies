using System;
using OpenGLDotNet;
using Common;

namespace OpenGLDemos
{
    public class ConvertPCX
    {     
        public static void ConvertTGA2PNG()
        {
            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.tga");
            //string[] folders = System.IO.Directory.GetDirectories(currentDirName);

            foreach (string tgaFile in files)
            {
                bool failed = false;

                Console.WriteLine("{0}", tgaFile);

                if (!IL.Load(IL.IL_TGA, tgaFile))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] Loading Failed");
                }
                if (!failed && !IL.ConvertImage(IL.IL_RGBA, IL.IL_UNSIGNED_BYTE))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] -->RGBA Conversion Failed");
                }
                if (!failed && !IL.Save(IL.IL_PNG, tgaFile.Replace(".tga", ".png")))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] -->PNG Saving Failed");
                }
            }
        }

        public static void ConvertPCX2PNG(string folder)
        {
            string[] files = System.IO.Directory.GetFiles(folder, "*.pcx");
            
            foreach (string pcxFile in files)
            {
                bool failed = false;

                Console.WriteLine("{0}", pcxFile);

                if (!IL.Load(IL.IL_PCX, pcxFile))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] Loading Failed");
                }

                if (!failed && !IL.LoadPal(@"C:\Development\Projects\OpenGLDotNet\bin\Debug\data\pics\colormap.pcx"))
                {
                    failed = true;
                    Console.WriteLine("[PALETTE] Loading Failed : colormap.pcx");
                }
                if (!failed && !IL.ConvertPal(IL.IL_PAL_RGBA32))
                {
                    failed = true;
                    Console.WriteLine("[PALETTE] -->RGBA32 Conversion Failed");
                }
                unsafe
                {
                    IntPtr Palette = IL.GetPalette();
                    byte* ptrPalette = (byte*)Palette;

                    if (Palette != IntPtr.Zero)
                    {
                        ptrPalette += 256 * 4 - 4;
                        *ptrPalette = 0xff;         // Red
                        ptrPalette++;
                        *ptrPalette = 0xff;         // Green
                        ptrPalette++;
                        *ptrPalette = 0xff;         // Blue
                        ptrPalette++;
                        *ptrPalette = 0x00;         // Alpha, transparent
                    }
                    else
                    {
                        failed = true;
                        Console.WriteLine("[PALETTE] -->NULL");
                    }
                }
                if (!failed && !IL.ConvertImage(IL.IL_RGBA, IL.IL_UNSIGNED_BYTE))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] -->RGBA Conversion Failed");
                }
                if (!failed && !IL.Save(IL.IL_PNG, pcxFile.Replace(".pcx", ".png")))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] -->PNG Saving Failed");
                }
            }
        
            string[] folders = System.IO.Directory.GetDirectories(folder);

            foreach(string directory in folders)
            {
                ConvertPCX2PNG(directory);
            }
        }

        public static void ConvertWAL2PNG(string folder)
        {
            string[] files = System.IO.Directory.GetFiles(folder, "*.wal");

            foreach (string walFile in files)
            {
                bool failed = false;

                Console.WriteLine("{0}", walFile);

                if (!IL.Load(IL.IL_WAL, walFile))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] Loading Failed");
                }

                /*
                if (!failed && !IL.LoadPal(@"C:\Development\Projects\OpenGLDotNet\bin\Debug\data\pics\colormap.pcx"))
                {
                    failed = true;
                    Console.WriteLine("[PALETTE] Loading Failed : colormap.pcx");
                }
                if (!failed && !IL.ConvertPal(IL.IL_PAL_RGBA32))
                {
                    failed = true;
                    Console.WriteLine("[PALETTE] -->RGBA32 Conversion Failed");
                }
                unsafe
                {
                    IntPtr Palette = IL.GetPalette();
                    byte* ptrPalette = (byte*)Palette;

                    if (Palette != IntPtr.Zero)
                    {
                        ptrPalette += 256 * 4 - 4;
                        *ptrPalette = 0xff;         // Red
                        ptrPalette++;
                        *ptrPalette = 0xff;         // Green
                        ptrPalette++;
                        *ptrPalette = 0xff;         // Blue
                        ptrPalette++;
                        *ptrPalette = 0x00;         // Alpha, transparent
                    }
                    else
                    {
                        failed = true;
                        Console.WriteLine("[PALETTE] -->NULL");
                    }
                }
                */
                if (!failed && !IL.ConvertImage(IL.IL_RGBA, IL.IL_UNSIGNED_BYTE))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] -->RGBA Conversion Failed");
                }
                if (!failed && !IL.Save(IL.IL_PNG, walFile.Replace(".wal", ".png")))
                {
                    failed = true;
                    Console.WriteLine("[TEXTURE] -->PNG Saving Failed");
                }
            }

            string[] folders = System.IO.Directory.GetDirectories(folder);

            foreach (string directory in folders)
            {
                ConvertWAL2PNG(directory);
            }
        }

        public static void Main(string[] args)
        {
            // First, setup the console window
            Console.Title = "OpenGLDotNet v1.0";
            Console.WindowWidth = 132;

            IL.Init();
            ILU.Init();
            ILUT.Init();

            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            ConvertWAL2PNG(currentDirName);

            IL.ShutDown();
        }
    }
}