<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="busqueda.aspx.cs" Inherits="HIRE.Vista.busqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <title>Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">


    <div class="row">

        <div class="col-md-2"></div>
        <div class="col-md-3">

            <div class="search-bar">
                <input type="text" placeholder="Search..." class="search-input">
                <button class="search-button">
                    <svg xmlns="http://www.w3.org/2000/svg" height="24" viewBox="0 96 960 960" width="24" fill="#ffffff">
                        <path d="M796 896 536 636q-30 26-67 39t-73 13q-99 0-169.5-70.5T156 448q0-99 70.5-169.5T396 208q99 0 169.5 70.5T636 448q0 38-12.5 74.5T584 588l260 260q12 12 11.5 28.5T844 905q-12 12-28 11.5T796 896ZM396 536q66 0 113-47t47-113q0-66-47-113t-113-47q-66 0-113 47t-47 113q0 66 47 113t113 47Z" />
                    </svg>
                </button>
            </div>


        </div>
        <div class="col-md-5"></div>
        <div class="col-md-2"></div>



    </div>




</asp:Content>
