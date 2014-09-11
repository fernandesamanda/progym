using ProjetoAcademia.Models;
using ProjetoAcademia.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoAcademia.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdministradorGeral conta)
        {
            AdministradorGeralRepository repository = new AdministradorGeralRepository();
            conta.Senha = Encrypt(conta.Senha);

            if (repository.Validar(ref conta))
            {
                FormsAuthentication.SetAuthCookie(conta.Nome, false);
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl != null)
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            ViewBag.Mensagem = "Login e/ou senha inválidos";
            return View();
        }

        public static string Encrypt(string senha)
        {
            var clearBytes = Encoding.UTF8.GetBytes(senha);
            using (var provider = new RijndaelManaged())
            {
                byte[] key = new byte[provider.KeySize / 8];
                byte[] initializationVector = new byte[provider.BlockSize / 8];
                ICryptoTransform transformer = provider.CreateEncryptor(key, initializationVector);
                using (var buffer = new MemoryStream())
                {
                    using (var stream = new CryptoStream(
                        stream: buffer, transform: transformer, mode: CryptoStreamMode.Write)
                        )
                    {
                        stream.Write(clearBytes, 0, clearBytes.Length);
                        stream.FlushFinalBlock();
                        return Convert.ToBase64String(buffer.ToArray());
                    }
                }


            }
        }





    }
}