// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
          new ApiResource("resourceCatalog"){Scopes= {"CatalogFullPermission","CatalogReadPermission"}},
          new ApiResource("resourceDiscount"){Scopes={"DiscountFullPermission"}},
          new ApiResource("resourceOrder"){Scopes={"OrderFullPermission"}},
          new ApiResource("resourceCargo"){Scopes={"CargoFullPermission"}},
          new ApiResource("resourceBasket"){Scopes={"BasketFullPermission"}},
          new ApiResource("resourceComment"){Scopes={"CommentFullPermission"}},
          new ApiResource("resourcePayment"){Scopes={"PaymentFullPermission"}},
          new ApiResource("resourceImages"){Scopes={"ImagesFullPermission"}},
          new ApiResource("resourceOcelot"){Scopes={"OcelotFullPermission"}},
          new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority For Catalog Operations"),
            new ApiScope("CatalogReadPermission","Reading Authority For Catalog Operations"),
            new ApiScope("DiscountFullPermission","Full Authority For Discount Operations"),
            new ApiScope("OrderFullPermission","Full Authority For Order Operations"),
            new ApiScope("CargoFullPermission","Full Authority For Cargo Operations"),
            new ApiScope("BasketFullPermission","Full Authority For Basket Operations"),
            new ApiScope("CommentFullPermission","Full Authority For Comment Operations"),
            new ApiScope("PaymentFullPermission","Full Authority For Payment Operations"),
            new ApiScope("ImagesFullPermission","Full Authority For Images Operations"),
            new ApiScope("OcelotFullPermission","Full Authority For Ocelot Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor Client
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "DiscountFullPermission", "CatalogFullPermission","CatalogReadPermission", "CommentFullPermission", "OcelotFullPermission", "PaymentFullPermission", "ImagesFullPermission" }
            },

            //Manager Client
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "BasketFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImagesFullPermission" }
            },

            //Admin Client
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission", "OcelotFullPermission","CommentFullPermission", "PaymentFullPermission", "ImagesFullPermission",

				IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 300
            }
            
        };
        
    }
}