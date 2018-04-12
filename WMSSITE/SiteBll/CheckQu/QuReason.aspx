<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuReason.aspx.cs" Inherits="SiteBll_CheckQu_QuReason" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../../CSS/extaspnet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" HideScrollbar="false"
            runat="server"></ext:PageManager>
    <ext:TabStrip ID="TabStrip1"  ShowBorder="true" ActiveTabIndex="0" 
            runat="server" AutoPostBack="True" OnTabIndexChanged="TabStrip1_TabIndexChanged">
    <Tabs>
    <ext:Tab ID="Tab1" EnableBackgroundColor="true" BodyPadding="2px" runat="server" Title="质量原因">
    <Items>
        <ext:Form ID="formzlyysearch" runat="server" EnableBackgroundColor="true" ShowHeader="false">
        <Rows>
        <ext:FormRow>
        <Items>
            <ext:DropDownList ID="SXSearch" runat="server" Label="属性" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="SXSearch_SelectedIndexChanged">
            </ext:DropDownList>
        </Items>
        </ext:FormRow>
        </Rows>
        </ext:Form>
        <ext:Panel runat="server" Title="质量原因列表" EnableBackgroundColor="True" ShowBorder="False" ID="panelsearch">
       <Items>
       <ext:Grid runat="server" AllowPaging="false" AutoPostBack="True" 
            EnableCheckBoxSelect="True" EnableMultiSelect="False" Title="" 
            ShowBorder="False" Height="430px" ID="GridSX"  AutoScroll="True" ShowHeader="false" OnRowClick="GridSX_RowClick">
            <Columns>
                <ext:BoundField DataField="SX" ColumnID="ct02" HeaderText="属性" ></ext:BoundField>
                <ext:BoundField DataField="Reason" ColumnID="ct03" HeaderText="原因"  ></ext:BoundField>
            </Columns>
       </ext:Grid>
    </Items>
    </ext:Panel>
    <ext:Panel runat="server" ID="afd" ShowHeader="false" EnableBackgroundColor="true">
    <Items>
       <ext:Form runat="server" ShowHeader="False" EnableBackgroundColor="True" BodyPadding="3px" ShowBorder="False" ID="formedt" Width="600px">
           <Rows>
              <ext:FormRow>
              <Items>
                 <ext:HiddenField runat="server" ID="ysx"></ext:HiddenField>
                 <ext:HiddenField runat="server" ID="yreason"></ext:HiddenField>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow4" runat="server">
              <Items>
                 <ext:DropDownList ID="SX" Width="150px" Label="属性" runat="server" AutoPostBack="True"></ext:DropDownList>
                 <ext:TextBox ID="Reason" Width="150px" runat="server" Label="质量原因" ></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow>
              <Items>
                  <ext:Panel runat="server" ID="panel2" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false" Layout="Column">
                           <Items>
                              <ext:Panel runat="server" ID="panel3" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false" Width="100px">
                              <Items>
                                    <ext:Label runat="server" ID="Label1" Text="."></ext:Label>
                              </Items>
                              </ext:Panel>
                              <ext:Panel runat="server" ID="panel4" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" BodyPadding="5px">
                              <Items>
                                 <ext:Button runat="server" ID="btnSpeClear" Text="清空" CssClass="inline" OnClick="btnSpeClear_Click" ></ext:Button>
                                 <ext:Button runat="server" ID="btnSpeAdd" Text="增加" CssClass="inline" OnClick="btnSpeAdd_Click"></ext:Button>
                                 <ext:Button runat="server" ID="btnSpeSave" Text="保存" CssClass="inline"  ValidateForms="form2"
                                  ConfirmIcon="Question" ConfirmText="是否保存？" OnClick="btnSpeSave_Click"></ext:Button>
                                  <ext:Button runat="server" ID="btnSpeDel" Text="删除"  CssClass="inline" OnClick="btnSpeDel_Click" ConfirmText="是否删除？"></ext:Button>
                              </Items>
                              </ext:Panel>
                           </Items>
                       </ext:Panel>
              </Items>
              </ext:FormRow>
           </Rows>
    </ext:Form>
    </Items>
    </ext:Panel>
    </Items>
    </ext:Tab>
    <ext:Tab ID="Tab2" EnableBackgroundColor="true" BodyPadding="2px" runat="server" Title="改判原因">
    <Items>
        <ext:Grid runat="server" AllowPaging="false" AutoPostBack="True" 
            EnableCheckBoxSelect="True" EnableMultiSelect="False" Title="改判原因列表" 
            ShowBorder="False" Height="430px" ID="gridGP"  AutoScroll="True" ShowHeader="true"  OnRowClick="gridGP_RowClick">
            <Columns>
                <ext:BoundField DataField="Reason" ColumnID="ct01" HeaderText="原因"  ></ext:BoundField>
            </Columns>
       </ext:Grid>
       <ext:Panel runat="server" ID="Panel1" ShowHeader="false" EnableBackgroundColor="true">
    <Items>
       <ext:Form runat="server" ShowHeader="False" EnableBackgroundColor="True" BodyPadding="3px" ShowBorder="False" ID="form2" Width="600px">
           <Rows>
              <ext:FormRow>
              <Items>
                 <ext:HiddenField runat="server" ID="yzlyy"></ext:HiddenField>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow1" runat="server">
              <Items>
                 <ext:TextBox ID="GPZLYY" Width="150px" runat="server" Label="质量原因" ></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow>
              <Items>
                  <ext:Panel runat="server" ID="panel5" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false" Layout="Column">
                           <Items>
                              <ext:Panel runat="server" ID="panel6" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false" Width="100px">
                              <Items>
                                    <ext:Label runat="server" ID="Label2" Text="."></ext:Label>
                              </Items>
                              </ext:Panel>
                              <ext:Panel runat="server" ID="panel7" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" BodyPadding="5px">
                              <Items>
                                 <ext:Button runat="server" ID="btnGPClear" Text="清空" CssClass="inline" OnClick="btnGPClear_Click" ></ext:Button>
                                 <ext:Button runat="server" ID="btnGPAdd" Text="增加" CssClass="inline" OnClick="btnGPAdd_Click"></ext:Button>
                                 <ext:Button runat="server" ID="btnGPSave" Text="保存" CssClass="inline"  ValidateForms="form2"
                                  ConfirmIcon="Question" ConfirmText="是否保存？" OnClick="btnGPSave_Click"></ext:Button>
                                  <ext:Button runat="server" ID="btnGPDel" Text="删除"  CssClass="inline" OnClick="btnGPDel_Click" ConfirmText="是否删除？"></ext:Button>
                              </Items>
                              </ext:Panel>
                           </Items>
                       </ext:Panel>
              </Items>
              </ext:FormRow>
           </Rows>
    </ext:Form>
    </Items>
    </ext:Panel>
    </Items>
    </ext:Tab>
        
    </Tabs>
    </ext:TabStrip>
    
    
    </form>
</body>
</html>
