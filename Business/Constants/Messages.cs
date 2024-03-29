﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameOrDailyPriceInvalid = "Araba ismi geçersiz veya günlük fiyat uygun değil";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarRentaled = "Araba kiralandı";
        public static string CarNotRentaled = "Araba kiralama işlemi başarısız oldu";
        public static string CarCountOfBrandError = "Aynı markadan 10'dan fazla araç eklenemez";
        public static string CarModelNameError = "Aynı isimde arac eklenemez !!";
        public static string CarModelNameAlreadyExists = "Model adı zaten ekli !!!";
        public static string BrandLimitExceded = "Marka sayisi, siniri asti !!";
        public static string AuthorizationDenied = "Yetkiniz yok !!!";
        public static string UserNotFound = "Kullanici bulunamadi ..";
        public static string PasswordError ="sifrenizi hatali girdiniz!";
        public static string SuccessfulLogin = "Giris basarili ";
        public static string UserAlreadyExists = "Kullanici zaten kayitli !";
        public static string AccessTokenCreated = "Token olusturuldu: ";
        public static string UserRegistered = "Kayit olundu. ";
    }
}
