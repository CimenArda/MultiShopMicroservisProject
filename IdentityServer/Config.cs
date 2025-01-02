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
                AllowedScopes = { "DiscountFullPermission" }
            },

            //Manager Client
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission",  }
            },

            //Admin Client
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission",
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