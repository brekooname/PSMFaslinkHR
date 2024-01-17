using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

//ducnm 13/05/2014
/// <summary>
/// tạo hiệu ứng gương trên form
/// </summary>
public class GlassForm
{
    public int GlassML = 0;
    public int GlassMR = 0;
    public int GlassMT = 0;
    public int GlassMB = 0;

    private Form _FormContrainer;
    public GlassForm(Form FormContrainer)
    {
        _FormContrainer = FormContrainer;
        _FormContrainer.Paint += _FormContrainer_Paint;
    }

    void _FormContrainer_Paint(object sender, PaintEventArgs e)
    {
        if (GlassML > 0)
            FillBlackRegion(e.Graphics, new Rectangle(0, 0, GlassML, _FormContrainer.Height));
        if (GlassMR > 0)
            FillBlackRegion(e.Graphics, new Rectangle(_FormContrainer.Width - GlassMR, 0, GlassMR, _FormContrainer.Height));
        if (GlassMT > 0)
            FillBlackRegion(e.Graphics, new Rectangle(0, 0, _FormContrainer.Width, GlassMT));
        if (GlassMB > 0)
            FillBlackRegion(e.Graphics, new Rectangle(0, _FormContrainer.Height - GlassMB, _FormContrainer.Width, GlassMB));
    }

    public void RegGlass(int GlassML = -1, int GlassMR = -1, int GlassMT = -1, int GlassMB = -1)
    {
        if (!IsCompositionEnabled)
            return;

        if (GlassMB != -1) this.GlassMB = GlassMB;
        if (GlassML != -1) this.GlassML = GlassML;
        if (GlassMR != -1) this.GlassMR = GlassMR;
        if (GlassMT != -1) this.GlassMT = GlassMT;

        MARGINS mg = new MARGINS();
        mg.m_Buttom = this.GlassMB;
        mg.m_Left = this.GlassML;
        mg.m_Right = this.GlassMR;
        mg.m_Top = this.GlassMT;

        DwmExtendFrameIntoClientArea(_FormContrainer.Handle, ref mg);
    }

    #region private property
    private const int DTT_COMPOSITED = (int)(1UL << 13);
    private const int DTT_GLOWSIZE = (int)(1UL << 11);

    //Text format consts
    private const int DT_SINGLELINE = 0x00000020;
    private const int DT_CENTER = 0x00000001;
    private const int DT_VCENTER = 0x00000004;
    private const int DT_NOPREFIX = 0x00000800;

    //Const for BitBlt
    private const int SRCCOPY = 0x00CC0020;


    //Consts for CreateDIBSection
    private const int BI_RGB = 0;
    private const int DIB_RGB_COLORS = 0;//color table in RGBs

    private struct MARGINS
    {
        public int m_Left;
        public int m_Right;
        public int m_Top;
        public int m_Buttom;
    };

    private struct POINTAPI
    {
        public int x;
        public int y;
    };

    private struct DTTOPTS
    {
        public uint dwSize;
        public uint dwFlags;
        public uint crText;
        public uint crBorder;
        public uint crShadow;
        public int iTextShadowType;
        public POINTAPI ptShadowOffset;
        public int iBorderSize;
        public int iFontPropId;
        public int iColorPropId;
        public int iStateId;
        public int fApplyOverlay;
        public int iGlowSize;
        public IntPtr pfnDrawTextCallback;
        public int lParam;
    };

    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    };

    private struct BITMAPINFOHEADER
    {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public int biCompression;
        public int biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public int biClrUsed;
        public int biClrImportant;
    };

    private struct RGBQUAD
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    };

    private struct BITMAPINFO
    {
        public BITMAPINFOHEADER bmiHeader;
        public RGBQUAD bmiColors;
    };
    #endregion

    #region API declares
    [DllImport("dwmapi.dll")]
    private static extern void DwmIsCompositionEnabled(ref int enabledptr);
    [DllImport("dwmapi.dll")]
    private static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margin);

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr GetDC(IntPtr hdc);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern int SaveDC(IntPtr hdc);
    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern int ReleaseDC(IntPtr hdc, int state);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr CreateCompatibleDC(IntPtr hDC);
    [DllImport("gdi32.dll", ExactSpelling = true)]
    private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern bool DeleteObject(IntPtr hObject);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern bool DeleteDC(IntPtr hdc);
    [DllImport("gdi32.dll")]
    private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

    [DllImport("UxTheme.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);
    [DllImport("UxTheme.dll", ExactSpelling = true, SetLastError = true)]
    private static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags1, int dwFlags2, ref RECT pRect);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, int ppvBits, IntPtr hSection, uint dwOffset);
    #endregion

    #region public static method
    private static bool? _IsCompositionEnabled = null;
    public static bool IsCompositionEnabled
    {
        get
        {
            if (_IsCompositionEnabled == null)
            {
                if (Environment.OSVersion.Version.Major < 6)
                {
                    _IsCompositionEnabled = false;
                }
                else
                {
                    int compositionEnabled = 0;
                    DwmIsCompositionEnabled(ref compositionEnabled);
                    _IsCompositionEnabled = (compositionEnabled > 0);
                }
            }

            return _IsCompositionEnabled.Value;
        }
    }

    public static void FillBlackRegion(Graphics gph, Rectangle rgn)
    {
        RECT rc = new RECT();
        rc.left = rgn.Left;
        rc.right = rgn.Right;
        rc.top = rgn.Top;
        rc.bottom = rgn.Bottom;

        IntPtr destdc = gph.GetHdc();    //hwnd must be the handle of form,not control
        IntPtr Memdc = CreateCompatibleDC(destdc);
        IntPtr bitmap;
        IntPtr bitmapOld = IntPtr.Zero;

        BITMAPINFO dib = new BITMAPINFO();
        dib.bmiHeader.biHeight = -(rc.bottom - rc.top);
        dib.bmiHeader.biWidth = rc.right - rc.left;
        dib.bmiHeader.biPlanes = 1;
        dib.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
        dib.bmiHeader.biBitCount = 32;
        dib.bmiHeader.biCompression = BI_RGB;
        if (!(SaveDC(Memdc) == 0))
        {
            bitmap = CreateDIBSection(Memdc, ref dib, DIB_RGB_COLORS, 0, IntPtr.Zero, 0);
            if (!(bitmap == IntPtr.Zero))
            {
                bitmapOld = SelectObject(Memdc, bitmap);
                BitBlt(destdc, rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top, Memdc, 0, 0, SRCCOPY);

            }

            //Remember to clean up
            SelectObject(Memdc, bitmapOld);

            DeleteObject(bitmap);

            ReleaseDC(Memdc, -1);
            DeleteDC(Memdc);


        }
        gph.ReleaseHdc();

    }

    public static void DrawTextOnGlass(IntPtr hwnd, String text, Font font, Rectangle ctlrct, int iglowSize)
    {
        if (!IsCompositionEnabled)
            return;

        RECT rc = new RECT();
        RECT rc2 = new RECT();

        rc.left = ctlrct.Left;
        rc.right = ctlrct.Right + 2 * iglowSize;  //make it larger to contain the glow effect
        rc.top = ctlrct.Top;
        rc.bottom = ctlrct.Bottom + 2 * iglowSize;

        //Just the same rect with rc,but (0,0) at the lefttop
        rc2.left = 0;
        rc2.top = 0;
        rc2.right = rc.right - rc.left;
        rc2.bottom = rc.bottom - rc.top;

        IntPtr destdc = GetDC(hwnd);    //hwnd must be the handle of form,not control
        IntPtr Memdc = CreateCompatibleDC(destdc);   // Set up a memory DC where we'll draw the text.
        IntPtr bitmap;
        IntPtr bitmapOld = IntPtr.Zero;
        IntPtr logfnotOld;

        int uFormat = DT_VCENTER | DT_NOPREFIX;   //text format

        BITMAPINFO dib = new BITMAPINFO();
        dib.bmiHeader.biHeight = -(rc.bottom - rc.top);         // negative because DrawThemeTextEx() uses a top-down DIB
        dib.bmiHeader.biWidth = rc.right - rc.left;
        dib.bmiHeader.biPlanes = 1;
        dib.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
        dib.bmiHeader.biBitCount = 32;
        dib.bmiHeader.biCompression = BI_RGB;
        if (!(SaveDC(Memdc) == 0))
        {
            bitmap = CreateDIBSection(Memdc, ref dib, DIB_RGB_COLORS, 0, IntPtr.Zero, 0);   // Create a 32-bit bmp for use in offscreen drawing when glass is on
            if (!(bitmap == IntPtr.Zero))
            {
                bitmapOld = SelectObject(Memdc, bitmap);
                IntPtr hFont = font.ToHfont();
                logfnotOld = SelectObject(Memdc, hFont);
                try
                {
                    System.Windows.Forms.VisualStyles.VisualStyleRenderer renderer = new System.Windows.Forms.VisualStyles.VisualStyleRenderer(System.Windows.Forms.VisualStyles.VisualStyleElement.Window.Caption.Active);
                    DTTOPTS dttOpts = new DTTOPTS();
                    dttOpts.dwSize = (uint)Marshal.SizeOf(typeof(DTTOPTS));
                    dttOpts.dwFlags = DTT_COMPOSITED | DTT_GLOWSIZE;
                    dttOpts.iGlowSize = iglowSize;
                    DrawThemeTextEx(renderer.Handle, Memdc, 0, 0, text, -1, uFormat, ref rc2, ref dttOpts);
                    BitBlt(destdc, rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top, Memdc, 0, 0, SRCCOPY);
                }
                catch
                {
                }

                //Remember to clean up
                SelectObject(Memdc, bitmapOld);
                SelectObject(Memdc, logfnotOld);
                DeleteObject(bitmap);
                DeleteObject(hFont);

                ReleaseDC(Memdc, -1);
                DeleteDC(Memdc);
            }
        }
    }
    #endregion
}

