<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SXSET.aspx.cs" Inherits="SiteBll_SysMan_SXSET" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>属性设置</title>
    <link href="../../CSS/extaspnet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" HideScrollbar="false"
            runat="server"></ext:PageManager>
     <ext:TabStrip ID="tabStrip" ShowBorder="true" ActiveTabIndex="0"
        runat="server" ontabindexchanged="btnQuery_TabIndexChanged" AutoPostBack=true>
        <Tabs>
            <ext:Tab ID="Tab1" Title="属性设置" EnableBackgroundColor="true" BodyPadding="5px"
                runat="server">
                <Items>
                     <ext:Panel runat="server" Title="属性列表" EnableBackgroundColor="True" ShowBorder="False" ID="panelsearch">
    <Items>
       <ext:Grid runat="server" AllowPaging="false" AutoPostBack="True" 
            EnableCheckBoxSelect="True" EnableMultiSelect="False" Title="" 
            ShowBorder="False" Height="350px" ID="GridSX" ShowHeader="false" OnRowClick="GridSX_RowClick">
            <Columns>
                <ext:BoundField DataField="SX" ColumnID="ct01" HeaderText="属性" ></ext:BoundField>
                <ext:BoundField DataField="SXName" ColumnID="ct02" HeaderText="属性名称"  ></ext:BoundField>
                <ext:BoundField DataField="ISBATCH" ColumnID="ct03" HeaderText="是否批次"  ></ext:BoundField>
                <ext:BoundField DataField="ISDEFAULTDJ" ColumnID="ct04" HeaderText="是否默认单卷" ></ext:BoundField>
                <ext:BoundField DataField="ISKN" ColumnID="ct05" HeaderText="是否库内属性"></ext:BoundField>
            </Columns>
       </ext:Grid>
    </Items>
    </ext:Panel>
    <ext:Form runat="server" ShowHeader="False" EnableBackgroundColor="True" BodyPadding="3px" ShowBorder="False" ID="formedt">
           <Rows>
              <ext:FormRow ID="FormRow1" runat="server">
              <Items>
                  <ext:TextBox runat="server" Label="属性" ID="SX" Required="true" Width="200px"></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow2" runat="server">
              <Items>
                  <ext:TextBox runat="server" Label="属性名称" ID="SXName" Required="true"  Width="200px"></ext:TextBox>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow5" runat="server">
              <Items>
                 <ext:DropDownList ID="ISBATCH" runat="server" Label="是否批次"  Width="200px">
                  <ext:ListItem  Value="Y" Text="Y"/>
                  <ext:ListItem  Value="N" Text="N"/>
                  </ext:DropDownList>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow3" runat="server">
              <Items>
                  <ext:DropDownList ID="ISDEFAULTDJ" runat="server" Label="是否默认单卷"  Width="200px">
                  <ext:ListItem  Value="Y" Text="Y"/>
                  <ext:ListItem  Value="N" Text="N"/>
                  </ext:DropDownList>
              </Items>
              </ext:FormRow>
              <ext:FormRow ID="FormRow4" runat="server">
              <Items>
                  <ext:DropDownList ID="ISKN" runat="server" Label="是否库内"  Width="200px">
                  <ext:ListItem  Value="Y" Text="Y"/>
                  <ext:ListItem  Value="N" Text="N"/>
                  </ext:DropDownList>
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
            </ext:Tab>
            <ext:Tab ID="Tab2" Title="称重属性" BodyPadding="5px"
                EnableBackgroundColor="true" runat="server">
                <Items>
                    <ext:Panel runat="server"  EnableBackgroundColor="True" ShowBorder="False" 
                        ID="panelsearch2" Title="称重属性列表" Height="350px" AnchorValue="100% -36">
                        <Items>
           <ext:Grid ID="GRIDCZSX" runat="server" AutoPostBack="True"
               EnableCheckBoxSelect="True" EnableMultiSelect="False" Height="350px" 
               OnRowClick="GRIDCZSX_RowClick" ShowBorder="False" ShowHeader="False">
               <Columns>
                   <ext:BoundField ColumnID="ct06" DataField="PCSX" HeaderText="批次属性" />
                   <ext:BoundField ColumnID="ct07" DataField="MRDJSX" HeaderText="默认单卷属性" />
                   <ext:BoundField ColumnID="ct08" DataField="DJSX" HeaderText="单卷属性" />
                   <ext:BoundField ColumnID="ct09" DataField="ORDERNUM" HeaderText="排序" />
               </Columns>
           </ext:Grid>
       </Items>
       </ext:Panel>
                    <ext:Form ID="formedt2" runat="server" BodyPadding="3px" 
                        EnableBackgroundColor="True" ShowBorder="False" ShowHeader="False">
                        <Rows>
                        <ext:FormRow ID="FormRow9" runat="server">
                        <Items>
                           <ext:DropDownList ID="PCSX" runat="server" Label="批次属性" Width="200px">
                            </ext:DropDownList>
                        </Items>
                        </ext:FormRow>
                            <ext:FormRow ID="FormRow12" runat="server">
                                <Items>
                                    <ext:DropDownList ID="MODJSX" runat="server" Label="默认单卷属性" Width="200px">
                            </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                             <ext:FormRow ID="FormRow10" runat="server">
                                <Items>
                                    <ext:DropDownList ID="DJSX" runat="server" Label="单卷属性" Width="200px">
                            </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow11" runat="server">
                                <Items>
                                  <ext:TextBox runat="server" Label="排序" ID="TXTPX" Text="1"
                      Width="150px" RegexPattern="NUMBER" Required="True"></ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow runat="server">
                                <Items>
                                    <ext:Panel ID="panel8" runat="server" EnableBackgroundColor="True" 
                                        Layout="Column" ShowBorder="False" ShowHeader="False">
                                        <Items>
                                            <ext:Panel ID="panel9" runat="server" BodyPadding="5px" 
                                                EnableBackgroundColor="True" ShowBorder="False" ShowHeader="False">
                                                <Items>
                                                    <ext:Button ID="btnSpeClearCZ" runat="server" CssClass="inline" 
                                                        OnClick="btnSpeClearCZ_Click" Text="清空">
                                                    </ext:Button>
                                                    <ext:Button ID="btnSpeAddCZ" runat="server" CssClass="inline" 
                                                        OnClick="btnSpeAdd_Click" Text="增加">
                                                    </ext:Button>
                                                    <ext:Button ID="btnSpeSaveCZ" runat="server" ConfirmIcon="Question" 
                                                        ConfirmText="是否保存？" CssClass="inline" OnClick="btnSpeSaveCZ_Click" Text="保存" 
                                                        ValidateForms="form2">
                                                    </ext:Button>
                                                    <ext:Button ID="btnSpeDelCZ" runat="server" ConfirmText="是否删除？" CssClass="inline" 
                                                        OnClick="btnSpeDelCZ_Click" Text="删除">
                                                    </ext:Button>
                                                </Items>
                                            </ext:Panel>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Tab>
        </Tabs>
    </ext:TabStrip>
    </form>
</body>
</html>
