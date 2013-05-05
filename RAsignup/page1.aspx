<%@ Page Language="C#" MasterPageFile="~/RAsignup/page1.master" AutoEventWireup="true" CodeFile="page1.aspx.cs" Inherits="RAsignup_page1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="jquery172.min.js"></script>
    <script type="text/javascript" src="jwplayer/jwplayer.js"></script>
    <script type="text/javascript" src="jwplayer/jwplayer-functions.js"></script>
    <link href="jwplayer/video.css" rel="stylesheet" type="text/css" />
    <link href="start.css" rel="stylesheet" type="text/css" />







    <script type="text/javascript">
        $(function () {
            $('INPUT[id*="txtConfemail"]').blur(function () {
                if ($('INPUT[id*="txtEmail"]').val() != $('INPUT[id*="txtConfemail"]').val()) {
    
    
                    alert('Please confirm your email.');
                    return false;
    
                }
            })
        });
    </script>


    <script type="text/javascript">
        function dothis() {
            //var allInputs = $(":input");
            //if($('#customerInformation INPUT[*]').val().length === 0)
            if ($('INPUT[id*="txtFirstName"]').val().length === 0 ||
                $('INPUT[id*="txtLastName"]').val().length === 0 ||
                $('INPUT[id*="txtPhone"]').val().length === 0 ||
                $('INPUT[id*="txtEmail"]').val().length === 0 ||
                $('INPUT[id*="txtEmail"]').val().length === 0) 
            {
                alert('All fields are required!');
                 return false;
            }
        }
    </script>



</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Content">

    <%--This script makes the YouTube video work. This must be placed here in the ContentPlaceHolderID: "Content"--%>
    <script type="text/javascript">loadJWvideoYouTube('x4_HzQmSWYM', 521, 346, '', true);</script>

    <p>
        <span style="font-size: 16px">Enter your name, phone number and email address to gain instant access to a free copy of <strong>The Strait Path to Real Estate Wealth</strong> and a short video sharing the singular best investment in America today! </span>
        <span style="font-size: 16px"></span>
    </p>

    <table id="customerInformation" style="width: 100%">
        <tr>
            <td style="text-align: left"><span class="required">*</span>First Name:</td>
            <td>
                <span class="label">
                    <span class="inputBox">
                        <asp:TextBox ID="txtFirstName" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="rtxtFirstName" runat="server" ControlToValidate="txtFirstName" SetFocusOnError="true" Display="Dynamic" ErrorMessage="(Required)" />
                    </span>
                </span>
            </td>
        </tr>
        <tr>
            <td style="text-align: left"><span class="required">*</span>Last Name: </td>
            <td>
                <span class="label">
                    <span class="inputBox">
                        <asp:TextBox ID="txtLastName" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="rtxtLastName" runat="server" ControlToValidate="txtLastName" SetFocusOnError="true" Display="Dynamic" ErrorMessage="(Required)" />
                    </span>
                </span>
            </td>
        </tr>
        <tr>
            <td style="text-align: left"><span class="required">*</span>Phone: </td>
            <td>
                <span class="label">
                    <span class="inputBox">
                        <asp:TextBox ID="txtPhone" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="rtxtPhone" runat="server" ControlToValidate="txtPhone" SetFocusOnError="true" Display="Dynamic" ErrorMessage="(Required)" />
                    </span>
                </span>
            </td>
        </tr>
        <tr>
            <td style="text-align: left"><span class="required">*</span>Email: </td>
            <td>
                <span class="label">
                    <span class="inputBox">
                        <asp:TextBox ID="txtEmail" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="rtxtEmail" runat="server" ControlToValidate="txtEmail" SetFocusOnError="true" Display="Dynamic" ErrorMessage="(Required)" />
                    </span>
                </span>
            </td>
        </tr>
        <tr>
            <td style="text-align: left"><span class="required">*</span>Confirm Email: </td>
            <td>
                <span class="label">
                    <span class="inputBox">
                        <asp:TextBox ID="txtConfemail" runat="server" /><br />
                        <asp:RequiredFieldValidator ID="rtxtConfemail" runat="server" ControlToValidate="txtConfemail" SetFocusOnError="true" Display="Dynamic" ErrorMessage="(Required)" />
                    </span>
                </span>
            </td>
        </tr>
        <tr style="display: none;">
            <td>
                <asp:TextBox ID="txtEnrollerID" runat="server" />
                <asp:TextBox ID="txtNewCustomerID" runat="server" />
                <asp:TextBox ID="txtUsername" runat="server" />
                <asp:TextBox ID="txtPassword" runat="server" />
                <asp:TextBox ID="txtPasswordConf" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <p></p>

    <asp:Button ID="nextButton1" CssClass="transImageLink" runat="server" OnClick="Click_NextPage" OnClientClick="dothis();" CausesValidation="true" />

    <p>&nbsp;</p>
</asp:Content>
