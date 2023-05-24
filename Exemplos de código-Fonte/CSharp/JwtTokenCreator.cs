using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegracaoInvoicy.Models
{
    public class JwtTokenCreator
    {
        /// <summary>
        /// Metodo para gerar Token de autenticação de forma automática.
        /// ** minutosExp deve ser inserido pelo usuário ou devemos tratar automaticamente? **
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="chaveDeAcesso"></param>
        /// <param name="chaveDeParceiro"></param>
        /// <param name="minutosExp"></param>
        /// <returns></returns>
        public static string GeraTokenJWT(RequestParams requestParams)
        {
            DateTime dtNow = DateTime.UtcNow;
            var exp = DateTime.Now.AddSeconds(requestParams.segundosExp);

            //int minutosExp = 15;  //este tempo deve ser curto, algo entre 15 até 50% da expiração do refresh token. quando expirar, será buscado novo token e refresh token no servidor.
            //if (isRefresh)
            //    minutosExp = 60;  //expiração do refresh token. este tempo é o máximo que ficará logado sem ação do usuário na interface. quando expirar, será feito logoff.

            SecurityTokenDescriptor Jwt = new SecurityTokenDescriptor
            {
                IssuedAt = dtNow,
                Expires = exp,
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, requestParams.cnpj),
                    new Claim("partnerKey", requestParams.chaveDeParceiro)
                })
            };

            var symmetricKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(requestParams.chaveDeAcesso));

            Jwt.SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.SetDefaultTimesOnTokenCreation = false;
            var token = tokenHandler.CreateToken(Jwt);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
