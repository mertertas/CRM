using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string DepartmentAdded = "Departman Eklendi.";
        public static string DepartmentDeleted = "Departman Silindi.";
        public static string DepartmentUptaded = "Departman Güncellendi.";

        public static string ProjectAdded = "Proje Eklendi.";
        public static string ProjectDeleted = "Proje Silindi.";
        public static string ProjectUptaded = "Proje Güncellendi.";

        public static string ServiceAdded = "Hizmet Eklendi.";
        public static string ServiceDeleted = "Hizmet Silindi.";
        public static string ServiceUptaded = "Hizmet Güncellendi.";

        public static string ServiceTransactionAdded = "Hizmet Hareketi Eklendi.";
        public static string ServiceTransactionDeleted = "Hizmet Hareketi Silindi.";
        public static string ServiceTransactionUptaded = "Hizmet Hareketi Güncellendi.";

        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerDeleted = "Müşteri Silindi.";
        public static string CustomerUptated = "Müşteri Güncellendi.";

        public static string PCategoryCountControlExceed = "Kategori Sayısı Aşıldığı İçin yeni Ürün Eklenemez.";
        public static string AuthorizationDenied = "Kullanıcın Yetkisi Yoktur.";
        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
