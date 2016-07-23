using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using HYJHLibrary;
using HYJHLibrary.modal;
using HYJHLibrary.bll;


namespace HYJHWeb
{
    public partial class RecvUpdateFile : HYJHLibrary.BasePage
    {
        protected static Point thumbImageSize;
        protected static Point ImageSize;
        protected string redirectUrl;
        protected string opMessage;

        static RecvUpdateFile()
        {
            thumbImageSize = new Point(178, 118);
            ImageSize = new Point(598, 478);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetSessionUser() == null)
                throw new Exception("您的登录状态已经过期");

            redirectUrl = "";
            opMessage = "";

            int houseId = 0;

            if (Request.Files["uploadimage"] == null)
            {
                opMessage = "没有待上传的目标文件";
                throw new Exception("没有文件");
            }

            if (Int32.TryParse(Request.Form["houseid"], out houseId) == false)
            {
                throw new Exception("houseid错误");
            }

            HouseInfo houseInfo = Houses.GetHouseInfo(houseId);

            if (houseInfo == null)
            {
                throw new Exception("未找到目标房源");
            }

            if ((CanDo(HYJHLibrary.modal.RoleBehavior.EditHouseInfo) == true || CanDo(RoleBehavior.CreateHouseInfo) == true ||
(CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) && houseInfo.UserId == GetSessionUser().UserId)) == false)
                throw new Exception("您没有权限为房源信息添加照片");

            redirectUrl = "houseEdit.aspx?houseId=" + houseId.ToString();

            HttpPostedFile uploadFile = Request.Files["uploadimage"];

            if (uploadFile != null)
            {
                int picId = 0;

                try
                {
                    picId = HousePictureHelper.RecvHttpPostedFile(HttpContext.Current, houseInfo.HouseId, uploadFile);
                    opMessage = "上传图片成功，即将返回";
                }
                catch(Exception ex)
                {
                    opMessage = ex.Message; 
                }

                Page.DataBind();
   
            }
        }

        protected override void OnError(EventArgs e)
        {            
            Response.Clear();
            Response.Write(Server.GetLastError().Message);
            Response.End();
            base.OnError(e);
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Write(Server.GetLastError().Message);
            Response.End();
        }
    }


    public static class ImageHelper
    {
        //public static int RecvHttpPostedFile(HttpContext context, int houseId, HttpPostedFile uploadfile)
        //{
        //    Image uploadImage = null;

        //    try
        //    {
        //        uploadImage = Image.FromStream(uploadfile.InputStream);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("图片文件格式错误:" + ex.Message);
        //    }

        //    string filename = Guid.NewGuid().ToString("N") + ".jpg";
        //    string thumbFilename = "thumb_" + filename;

        //    #region 保存原始图片
        //    try
        //    {
        //        Image houseImage = ImageHelper.GetThumbnailImageKeepRatio(uploadfile, ImageSize.X, ImageSize.Y);
        //        houseImage.Save(context.Request.MapPath("/pic/" + filename), ImageFormat.Jpeg);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("图片保存失败");
        //    }
        //    #endregion

        //    #region 保存缩略图
        //    try
        //    {
        //        Image houseThumbImage = ImageHelper.GetThumbnailImageKeepRatio(uploadImage, thumbImageSize.X, thumbImageSize.Y);
        //        houseThumbImage.Save(context.Request.MapPath("/pic/" + thumbFilename), ImageFormat.Jpeg);
        //    }
        //    catch (Exception)
        //    {
        //        //如果缩略图保存失败， 那么删除之前保存的图片
        //        try
        //        {
        //            System.IO.File.Delete(context.Request.MapPath("/pic/" + filename));
        //        }
        //        catch (Exception)
        //        {

        //        }

        //        throw new Exception("图片缩略图保存失败");
        //    }
        //    #endregion

        //    #region 录入数据库
        //    try
        //    {
        //        int ret = Houses.CreateHousePicture(houseId, filename);

        //        if (ret == -1)
        //        {
        //            throw new Exception("指定的房源不存在");
        //        }

        //        if (ret == 0)
        //        {
        //            throw new Exception("图片录入数据库失败");
        //        }

        //        return ret;

        //        //redirectUrl = "houseEdit.aspx?houseid=" + houseId.ToString();

        //        //opMessage = "图片上传成功";

        //        //Page.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.IO.File.Delete(context.Request.MapPath("/pic/" + filename));
        //        System.IO.File.Delete(context.Request.MapPath("/pic/" + thumbFilename));
        //        throw new Exception("录入数据库失败:" + ex.Message);
        //    }
        //}

        /// 获取缩略图
        public static Image GetThumbnailImage(Image image, int width, int height)
        {
            if (image == null || width < 1 || height < 1)
                return null;
            // 新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(width, height);

            // 新建一个画板
            using (Graphics g = System.Drawing.Graphics.FromImage(bitmap))
            {

                // 设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // 设置高质量,低速度呈现平滑程度
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                // 高质量、低速度复合
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // 清空画布并以透明背景色填充
                g.Clear(Color.Transparent);

                // 在指定位置并且按指定大小绘制原图片的指定部分
                g.DrawImage(image, new Rectangle(0, 0, width, height),
                  new Rectangle(0, 0, image.Width, image.Height),
                  GraphicsUnit.Pixel);
                return bitmap;
            }
        }
        /// <summary>
        /// 生成缩略图，并保持纵横比
        /// </summary>
        /// <returns>生成缩略图后对象</returns>
        public static Image GetThumbnailImageKeepRatio(Image image, int width, int height)
        {
            Size imageSize = GetImageSize(image, width, height);
            return GetThumbnailImage(image, imageSize.Width, imageSize.Height);
        }

        /// <summary>
        /// 根据百分比获取图片的尺寸
        /// </summary>
        public static Size GetImageSize(Image picture, int percent)
        {
            if (picture == null || percent < 1)
                return Size.Empty;

            int width = picture.Width * percent / 100;
            int height = picture.Height * percent / 100;

            return GetImageSize(picture, width, height);
        }
        /// <summary>
        /// 根据设定的大小返回图片的大小，考虑图片长宽的比例问题
        /// </summary>
        public static Size GetImageSize(Image picture, int width, int height)
        {
            if (picture == null || width < 1 || height < 1)
                return Size.Empty;
            Size imageSize;
            imageSize = new Size(width, height);
            double heightRatio = (double)picture.Height / picture.Width;
            double widthRatio = (double)picture.Width / picture.Height;
            int desiredHeight = imageSize.Height;
            int desiredWidth = imageSize.Width;
            imageSize.Height = desiredHeight;
            if (widthRatio > 0)
                imageSize.Width = Convert.ToInt32(imageSize.Height * widthRatio);
            if (imageSize.Width > desiredWidth)
            {
                imageSize.Width = desiredWidth;
                imageSize.Height = Convert.ToInt32(imageSize.Width * heightRatio);
            }
            return imageSize;
        }
        /// <summary>
        /// 获取图像编码解码器的所有相关信息
        /// </summary>
        /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
        /// <returns>返回图像编码解码器的所有相关信息</returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }
        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo icf in encoders)
            {
                if (icf.FormatID == format.Guid)
                {
                    return icf;
                }
            }
            return null;
        }
        public static void SaveImage(Image image, string savePath, ImageFormat format)
        {
            SaveImage(image, savePath, GetImageCodecInfo(format));
        }
        /// <summary>
        /// 高质量保存图片
        /// </summary>
        private static void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            // 设置 原图片 对象的 EncoderParameters 对象
            EncoderParameters parms = new EncoderParameters(1);
            EncoderParameter parm = new EncoderParameter(Encoder.Quality, ((long)95));
            parms.Param[0] = parm;
            image.Save(savePath, ici, parms);
            parms.Dispose();
        }

    }
}