﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Godsend.Migrations
{
    public partial class new228 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkProductsSuppliers_Products_ProductId",
                table: "LinkProductsSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkProductsSuppliers_Suppliers_SupplierId",
                table: "LinkProductsSuppliers");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "LinkProductsSuppliers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "LinkProductsSuppliers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkProductsSuppliers_Products_ProductId",
                table: "LinkProductsSuppliers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkProductsSuppliers_Suppliers_SupplierId",
                table: "LinkProductsSuppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkProductsSuppliers_Products_ProductId",
                table: "LinkProductsSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkProductsSuppliers_Suppliers_SupplierId",
                table: "LinkProductsSuppliers");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "LinkProductsSuppliers",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "LinkProductsSuppliers",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_LinkProductsSuppliers_Products_ProductId",
                table: "LinkProductsSuppliers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkProductsSuppliers_Suppliers_SupplierId",
                table: "LinkProductsSuppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
