﻿using System.Net.Http.Json;
using static HendInRentApi.RentInHendApiConstants;

namespace HendInRentApi
{
    





    //eto obolochki nad api chtobi kazdiy raz ne pisat http zaprosi
    public class AuthRentInHendApi
    {
        static string auth_uri = APIURL + POST_AUTH_LOGIN; //kuda delat zapros
        public async Task<OutputAuthTokenDto> Login(InputLoginUserRentInHendDto user) //delaet zapros po puti /v1/login
        {
            HttpClient client = new HttpClient();
            client.AddHeadersWithoutBearer(); //Zdec nuzna nastroyka X-CSRF-TOKEN


            var response = await client.PostAsJsonAsync(auth_uri, user); // zapros - zdec ya ispolzuyu kak raz api

            await response.StatusIsOKOrThrowException(auth_uri); // esli ne OK to vidaet oshibku

            var result = await response.Content.ReadJsonByNewtonsoft<OutputAuthTokenDto>() ?? throw new NullReferenceException();
            //zdec mi poluchaem c# object iz otveta

            return result;

        }




        public void Logout()
        {
            //potom sdelayu
        }
    }


}
