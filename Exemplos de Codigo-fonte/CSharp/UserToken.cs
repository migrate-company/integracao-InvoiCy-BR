using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegracaoInvoicy.Models
{
    public class UserToken
    {
        public string accessToken { get; set; } // o token de acesso para ser enviado nas requisições
        public long accessTokenExpireAt { get; set; } // a data de expiração do accessToken desde a Era Unix
        public string refreshToken { get; set; } // o token para renovação do token de acesso
        public long refreshTokenExpireAt { get; set; } // a data de expiração do refreshToken desde a Era Unix
    }
}

//public long iat { get; set; }
//public long exp { get; set; }
//public string sub { get; set; }
//public string partnerKey { get; set; }
