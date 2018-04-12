<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmHWGZManage.aspx.cs" Inherits="SiteBll_SysMan_frmHWGZManage" %>

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
    <ext:Panel runat="server" Title="规则列表" EnableBackgroundColor="True" ShowBorder="False" ID="panelsearch">
    <Items>
       <ext:Grid runat="server" AllowPaging="false" AutoPostBack="True" 
            EnableCheckBoxSelect="True" EnableMultiSelect="False" Title="" 
            ShowBorder="False" Height="350px" ID="GridSX"  AutoScroll="True" ShowHeader="false" OnRowClick="GridSX_RowClick">
            <Columns>
                <ext:BoundField DataField="FID" ColumnID="ct00" Hidden="true"  Width="60px"></ext:BoundField>
                <ext:BoundField DataField="PHSET" ColumnID="ct01" Hidden="true"  Width="60px"></ext:BoundField>
                <ext:BoundField DataField="PHSETMS" ColumnID="ct02" HeaderText="牌号规则" ></ext:BoundField>
                <ext:BoundField DataField="PH" ColumnID="ct03" HeaderText="牌号"  ></ext:BoundField>
                <ext:BoundField DataField="GGSET" ColumnID="ct04" Hidden="true"  Width="60px"></ext:BoundField>
                <ext:BoundField DataField="GGSETMS" ColumnID="ct05" HeaderText="规格规则" ></ext:BoundField>
                <ext:BoundField DataField="GG" ColumnID="ct06" HeaderText="规格" ></ext:BoundField>
                <ext:BoundField DataField="PCHSET" ColumnID="ct07" Hidden="true"  Width="60px"></ext:BoundField>
                <ext:BoundField DataField="PCHSETMS" ColumnID="ct08" HeaderText="批次规则" ></ext:BoundField>
                <ext:BoundField DataField="PCH" ColumnID="ct09" HeaderText="批次" ></ext:BoundField>
                <ext:BoundField DataField="SXSET" ColumnID="ct10" Hidden="true"  Width="60px"></ext:BoundField>
                <ext:BoundField DataField="SXSETMS" ColumnID="ct11" HeaderText="属性规则" ></ext:BoundField>
                <ext:BoundField DataField="SX" ColumnID="ct12" HeaderText="属性" ></ext:BoundField>
                <ext:BoundField DataField="PCINFOSET" ColumnID="ct13" Hidden="true"  Width="60px"></ext:BoundField>
                <ext:BoundField DataField="PCINFOSETMS" ColumnID="ct14" HeaderText="特殊信息规则" ></ext:BoundField>
                <ext:BoundField DataField="PCINFO" ColumnID="ct15" HeaderText="特殊信息" ></ext:BoundField>
                <ext:BoundField DataField="WLHSET" ColumnID="ct16" Hidden="true" Width="60px"></ext:BoundField>
                <ext:BoundField DataField="WLHSETMS" ColumnID="ct17" HeaderText="物料号规则" ></ext:BoundField>
                <ext:BoundField DataField="WLH" ColumnID="ct18" HeaderText="物料号" ></ext:BoundField>
                <ext:BoundField DataField="YX" ColumnID="ct19" HeaderText="存放许可" ></ext:BoundField>
                <ext:BoundField DataField="YXJ" ColumnID="ct20" HeaderText="优先级" ></ext:BoundField>
            </Columns>
       </ext:Grid>
    </Items>
    </ext:Panel>
    <ext:Panel runat="server" ID="afd" ShowHeader="false">
    <Items>
       <ext:Form runat="server" ShowHeader="False" EnableBackgroundColor="True" BodyPadding="3px" ShowBorder="False" ID="formedt" Width="600px">
           <Rows>
              <ext:FormRow>
              <Items>
                  <ext:HiddenField ID="fid" runat="server"></ext:HiddenField>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow1" runat="server">
              <Items>
                  <ext:DropDownList ID="PHSET" runat="server" Label="牌号规则"  Width="150px" AutoPostBack="True" OnSelectedIndexChanged="PHSET_SelectedIndexChanged">
                  <ext:ListItem  Value="0" Text="无" Selected="true"/>
                  <ext:ListItem  Value="1" Text="相同"/>
                  <ext:ListItem  Value="2" Text="不同"/>
                  <ext:ListItem  Value="3" Text="特定"/>
                  </ext:DropDownList>
                  <ext:TextBox runat="server" Label="特定牌号" ID="PH"  Enabled="false" Width="150px"></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow2" runat="server">
              <Items>
                  <ext:DropDownList ID="GGSET" runat="server" Label="规格规则"  Width="150px" AutoPostBack="True" OnSelectedIndexChanged="GGSET_SelectedIndexChanged">
                  <ext:ListItem  Value="0" Text="无" Selected="true"/>
                  <ext:ListItem  Value="1" Text="相同"/>
                  <ext:ListItem  Value="2" Text="不同"/>
                  <ext:ListItem  Value="3" Text="特定"/>
                  </ext:DropDownList>
                  <ext:TextBox runat="server" Label="特定规格" ID="GG"  Enabled="false" Width="150px"></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow3" runat="server">
              <Items>
                  <ext:DropDownList ID="PCHSET" runat="server" Label="批次规则"  Width="150px" AutoPostBack="True" OnSelectedIndexChanged="PCHSET_SelectedIndexChanged">
                  <ext:ListItem  Value="0" Text="无" Selected="true"/>
                  <ext:ListItem  Value="1" Text="相同"/>
                  <ext:ListItem  Value="2" Text="不同"/>
                  <ext:ListItem  Value="3" Text="特定"/>
                  </ext:DropDownList>
                  <ext:TextBox runat="server" Label="特定批次号" ID="PCH"  Enabled="false" Width="150px"></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow4" runat="server">
              <Items>
                  <ext:DropDownList ID="SXSET" runat="server" Label="属性规则"  Width="150px" AutoPostBack="True" OnSelectedIndexChanged="SXSET_SelectedIndexChanged">
                  <ext:ListItem  Value="0" Text="无" Selected="true"/>
                  <ext:ListItem  Value="1" Text="相同"/>
                  <ext:ListItem  Value="2" Text="不同"/>
                  <ext:ListItem  Value="3" Text="特定"/>
                  </ext:DropDownList>
                  <ext:DropDownList ID="SX" Enabled="false" Width="150px" Label="特定属性" runat="server" AutoPostBack="True"></ext:DropDownList>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow5" runat="server">
              <Items>
                  <ext:DropDownList ID="PCINFOSET" runat="server" Label="特殊信息规则"  Width="150px" AutoPostBack="True" OnSelectedIndexChanged="PCINFOSET_SelectedIndexChanged">
                  <ext:ListItem  Value="0" Text="无" Selected="true"/>
                  <ext:ListItem  Value="1" Text="相同"/>
                  <ext:ListItem  Value="2" Text="不同"/>
                  <ext:ListItem  Value="3" Text="特定"/>
                  </ext:DropDownList>
                  <ext:TextBox runat="server" Label="特殊信息" ID="PCINFO"  Enabled="false" Width="150px"></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow6" runat="server">
              <Items>
                  <ext:DropDownList ID="WLHSET" runat="server" Label="物料号规则"  Width="150px" 
                      AutoPostBack="True" OnSelectedIndexChanged="WLHSET_SelectedIndexChanged">
                  <ext:ListItem  Value="0" Text="无" Selected="true"/>
                  <ext:ListItem  Value="1" Text="相同"/>
                  <ext:ListItem  Value="2" Text="不同"/>
                  <ext:ListItem  Value="3" Text="特定"/>
                  </ext:DropDownList>
                  <ext:TextBox runat="server" Label="物料号" ID="WLH"  Enabled="false" Width="150px"></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow>
              <Items>
                  <ext:DropDownList ID="YX" runat="server" Label="存放许可"  Width="150px">
                  <ext:ListItem  Value="Y" Text="Y" Selected="true"/>
                  <ext:ListItem  Value="N" Text="N"/>
                  </ext:DropDownList>
                  <ext:TextBox runat="server" Label="优先级" ID="txtYXJ" 
                      Width="150px" RegexPattern="NUMBER" Required="True"></ext:TextBox>
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
    
    </form>
</body>
</html>
