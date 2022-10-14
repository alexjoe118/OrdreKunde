
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace OrdreKunde.Model
{
    public class DBInit
    {
        public static void init(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DB>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var nyKunde = new Kunde
                {
                    FirstName = "Ole",
                    LastName = " Hansen",
                    Email = "fresh.dev@study.com",
                    Address = "Killer St No.10 5th"
                };

                var nyOrdre = new Ordre
                {
                    Dato = "23.05.2017"
                };

                var nyStock1 = new Stock
                {
                    Pris = 2.34,
                    Navn = "Gold"
                };
                var nyStock2 = new Stock
                {
                    Pris = 3.34,
                    Navn = "Silver"
                };
                var nyStock3 = new Stock
                {
                    Pris = 4.34,
                    Navn = "HBO"
                };

                var nyStock4 = new Stock
                {
                    Pris = 5.34,
                    Navn = "Disney"
                }; 
                var nyOrdreLinje1 = new OrdreLinje
                {
                    Stock = nyStock1,
                    Antall = 100,
                   
                };
                var nyOrdreLinje2 = new OrdreLinje
                {
                    Stock = nyStock2,
                    Antall = 50
                };

                var nyOrdreLinje3 = new OrdreLinje
                {
                    Stock = nyStock3,
                    Antall = 30
                };
                var nyOrdreLinje4 = new OrdreLinje
                {
                    Stock = nyStock4,
                    Antall = 20
                };

                // legg ordrelinjene inn i den nye ordren
                // det eksisterer ingen Liste av ordrelinjer i ordren fra før av så den må opprettes!
                var nyeOrdreLinjer = new List<OrdreLinje>();
                nyeOrdreLinjer.Add(nyOrdreLinje1);
                nyeOrdreLinjer.Add(nyOrdreLinje2);
                nyeOrdreLinjer.Add(nyOrdreLinje3);
                nyeOrdreLinjer.Add(nyOrdreLinje4);

                nyOrdre.OrdreLinjer = nyeOrdreLinjer;

                // det eksisterer ingen Liste av ordre i kunden så den må opprettes først!
                var nyeOrdre = new List<Ordre>();
                nyeOrdre.Add(nyOrdre);
                nyKunde.Ordre = nyeOrdre;

                // legg hele kunden med alle dataene inn i databasen
                context.Kunde.Add(nyKunde);
                context.SaveChanges();

                var nyKunde1 = new Kunde
                {
                    FirstName = "Narges",
                    LastName = " Fresh",
                    Email = "fresh.student@study.com",
                    Address = "God st No.10 5th"
                };

                var nyOrdre1 = new Ordre
                {
                    Dato = "13.10.2022"
                };

                nyStock1 = new Stock
                {
                    Pris = 100,
                    Navn = "Gold"
                };
                nyStock2 = new Stock
                {
                    Pris = 60.8,
                    Navn = "Silver"
                };
                nyStock3 = new Stock
                {
                    Pris = 66.34,
                    Navn = "HBO"
                };

                nyStock4 = new Stock
                {
                    Pris = 34.5,
                    Navn = "Disney"
                };
                nyOrdreLinje1 = new OrdreLinje
                {
                    Stock = nyStock1,
                    Antall = 30,

                };
                nyOrdreLinje2 = new OrdreLinje
                {
                    Stock = nyStock2,
                    Antall = 20
                };

                nyOrdreLinje3 = new OrdreLinje
                {
                    Stock = nyStock3,
                    Antall = 60
                };
                nyOrdreLinje4 = new OrdreLinje
                {
                    Stock = nyStock4,
                    Antall = 80
                };

                // legg ordrelinjene inn i den nye ordren
                // det eksisterer ingen Liste av ordrelinjer i ordren fra før av så den må opprettes!
                nyeOrdreLinjer = new List<OrdreLinje>();
                nyeOrdreLinjer.Add(nyOrdreLinje1);
                nyeOrdreLinjer.Add(nyOrdreLinje2);
                nyeOrdreLinjer.Add(nyOrdreLinje3);
                nyeOrdreLinjer.Add(nyOrdreLinje4);

                nyOrdre.OrdreLinjer = nyeOrdreLinjer;

                // det eksisterer ingen Liste av ordre i kunden så den må opprettes først!
                nyeOrdre = new List<Ordre>();
                nyeOrdre.Add(nyOrdre);
                nyKunde.Ordre = nyeOrdre;

                // legg hele kunden med alle dataene inn i databasen
                context.Kunde.Add(nyKunde1);
                context.SaveChanges();


            }

        }
    }
}

