"use strict";(self.webpackChunksakai_ng=self.webpackChunksakai_ng||[]).push([[242,720,225],{8225:(b,v,a)=>{a.d(v,{G:()=>t});var p=a(553),r=a(5849),h=a(1474);let t=(()=>{class d{constructor(c){this.http=c}CategoryrAdd(c){return this.http.post(`${p.N.apiUrl}/api/CategoryAPI/CreateorUpdateCategory`,c)}CategoryDelete(c){return this.http.delete(`${p.N.apiUrl}/api/CategoryAPI/DeleteCategory/`+c)}getAllCategories(){return this.http.get(`${p.N.apiUrl}/api/CategoryAPI/GetAllCategories`)}getCategoryById(c){return this.http.get(`${p.N.apiUrl}/api/CategoryAPI/GetCategoryById/${c}`)}static#t=this.\u0275fac=function(T){return new(T||d)(r.LFG(h.eN))};static#e=this.\u0275prov=r.Yz7({token:d,factory:d.\u0275fac,providedIn:"root"})}return d})()},4242:(b,v,a)=>{a.r(v),a.d(v,{StockModule:()=>ht});var p=a(6814),r=a(228),h=a(5219),t=a(5849),d=a(7209),M=a(9697),c=a(9720),T=a(8225),Z=a(7213),x=a(354),A=a(3965),k=a(3714),u=a(6340),y=a(4104),g=a(4480),f=a(707),_=a(95),C=a(6916),S=a(1532);function q(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"div",16)(1,"button",17),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.openNew())}),t.qZA(),t.TgZ(2,"button",18),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.deleteSelectedStocks())}),t.qZA()()}if(2&o){const e=t.oxw();t.xp6(2),t.Q6J("disabled",!e.selectedStocks||!e.selectedStocks.length)}}function N(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"div",19)(1,"h5",20),t._uU(2,"Manage Stocks"),t.qZA(),t.TgZ(3,"span",21),t._UZ(4,"i",22),t.TgZ(5,"input",23),t.NdJ("input",function(n){t.CHM(e);const s=t.oxw(),m=t.MAs(7);return t.KtG(s.onGlobalFilter(m,n))}),t.qZA()()()}}function D(o,l){1&o&&(t.TgZ(0,"tr")(1,"th",24),t._UZ(2,"p-tableHeaderCheckbox"),t.qZA(),t.TgZ(3,"th",25),t._uU(4,"Id "),t._UZ(5,"p-sortIcon",26),t.qZA(),t.TgZ(6,"th",27),t._uU(7,"Product Name "),t._UZ(8,"p-sortIcon",28),t.qZA(),t.TgZ(9,"th",29),t._uU(10,"Vendor Name"),t._UZ(11,"p-sortIcon",30),t.qZA(),t.TgZ(12,"th",31),t._uU(13,"Category Name"),t._UZ(14,"p-sortIcon",32),t.qZA(),t.TgZ(15,"th",33),t._uU(16,"Price Per Product "),t._UZ(17,"p-sortIcon",34),t.qZA(),t.TgZ(18,"th",35),t._uU(19,"Quantity "),t._UZ(20,"p-sortIcon",36),t.qZA(),t.TgZ(21,"th",37),t._uU(22,"Batch "),t._UZ(23,"p-sortIcon",38),t.qZA(),t.TgZ(24,"th",39),t._uU(25,"Manufacturing Date "),t._UZ(26,"p-sortIcon",40),t.qZA(),t.TgZ(27,"th",41),t._uU(28,"Expiry Date "),t._UZ(29,"p-sortIcon",42),t.qZA(),t.TgZ(30,"th",43),t._uU(31,"In Stock "),t._UZ(32,"p-sortIcon",44),t.qZA(),t._UZ(33,"th"),t.qZA())}function P(o,l){if(1&o&&(t.TgZ(0,"tr")(1,"td"),t._UZ(2,"p-tableCheckbox",45),t.qZA(),t.TgZ(3,"td",46)(4,"span",47),t._uU(5,"Id"),t.qZA(),t._uU(6),t.qZA(),t.TgZ(7,"td",46)(8,"span",47),t._uU(9,"Product Name"),t.qZA(),t._uU(10),t.qZA(),t.TgZ(11,"td",46)(12,"span",47),t._uU(13,"Vendor Name"),t.qZA(),t._uU(14),t.qZA(),t.TgZ(15,"td",46)(16,"span",47),t._uU(17,"Category Name"),t.qZA(),t._uU(18),t.qZA(),t.TgZ(19,"td",48)(20,"span",47),t._uU(21,"Price"),t.qZA(),t._uU(22),t.ALo(23,"currency"),t.qZA(),t.TgZ(24,"td",46)(25,"span",47),t._uU(26,"Quantity"),t.qZA(),t._uU(27),t.qZA(),t.TgZ(28,"td",46)(29,"span",47),t._uU(30,"Batch"),t.qZA(),t._uU(31),t.qZA(),t.TgZ(32,"td",46)(33,"span",47),t._uU(34,"ManufacturingDate"),t.qZA(),t._uU(35),t.qZA(),t.TgZ(36,"td",46)(37,"span",47),t._uU(38,"ExpiryDate"),t.qZA(),t._uU(39),t.qZA(),t.TgZ(40,"td",46)(41,"span",47),t._uU(42,"inStock"),t.qZA(),t._uU(43),t.qZA(),t.TgZ(44,"td"),t._UZ(45,"div",49),t.qZA()()),2&o){const e=l.$implicit;t.xp6(2),t.Q6J("value",e),t.xp6(4),t.hij(" ",e.stockId," "),t.xp6(4),t.hij(" ",e.productName," "),t.xp6(4),t.hij(" ",e.vendorName," "),t.xp6(4),t.hij(" ",e.categoryName," "),t.xp6(4),t.hij(" ",t.xi3(23,11,e.rate,"PKR ")," "),t.xp6(5),t.hij(" ",e.quantity," "),t.xp6(4),t.hij(" ",e.batch," "),t.xp6(4),t.hij(" ",e.manufacturingDate," "),t.xp6(4),t.hij(" ",e.expiryDate," "),t.xp6(4),t.hij(" ",e.inStock," ")}}function w(o,l){if(1&o&&(t.TgZ(0,"span"),t._uU(1),t.qZA()),2&o){const e=t.oxw(3);t.xp6(1),t.hij(" ",e.productMap[e.stock.productId]," ")}}function E(o,l){if(1&o&&t.YNc(0,w,2,1,"span",72),2&o){const e=t.oxw(2);t.Q6J("ngIf",e.stock.productId)}}function R(o,l){if(1&o&&(t.TgZ(0,"span"),t._uU(1),t.qZA()),2&o){const e=l.$implicit;t.Tol("product-badge status-"+e.id),t.xp6(1),t.Oqu(e.productName)}}function L(o,l){if(1&o&&(t.TgZ(0,"span"),t._uU(1),t.qZA()),2&o){const e=t.oxw(3);t.xp6(1),t.hij(" ",e.vendorMap[e.stock.vendorId]," ")}}function J(o,l){if(1&o&&t.YNc(0,L,2,1,"span",72),2&o){const e=t.oxw(2);t.Q6J("ngIf",e.stock.vendorId)}}function Q(o,l){if(1&o&&(t.TgZ(0,"span"),t._uU(1),t.qZA()),2&o){const e=l.$implicit;t.Tol("product-badge status-"+e.id),t.xp6(1),t.Oqu(e.vendorName)}}function F(o,l){if(1&o&&(t.TgZ(0,"span"),t._uU(1),t.qZA()),2&o){const e=t.oxw(3);t.xp6(1),t.hij(" ",e.categoryMap[e.stock.categoryId]," ")}}function B(o,l){if(1&o&&t.YNc(0,F,2,1,"span",72),2&o){const e=t.oxw(2);t.Q6J("ngIf",e.stock.categoryId)}}function O(o,l){if(1&o&&(t.TgZ(0,"span"),t._uU(1),t.qZA()),2&o){const e=l.$implicit;t.Tol("product-badge status-"+e.id),t.xp6(1),t.Oqu(e.categoryName)}}function G(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"div",50)(1,"label",51),t._uU(2,"Product Names"),t.qZA(),t.TgZ(3,"p-dropdown",52),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.productId=n)}),t.YNc(4,E,1,1,"ng-template",53)(5,R,2,3,"ng-template",54),t.qZA()(),t.TgZ(6,"div",50)(7,"label",55),t._uU(8,"Vendor Names"),t.qZA(),t.TgZ(9,"p-dropdown",56),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.vendorId=n)}),t.YNc(10,J,1,1,"ng-template",53)(11,Q,2,3,"ng-template",54),t.qZA()(),t.TgZ(12,"div",50)(13,"label",57),t._uU(14,"Category Names"),t.qZA(),t.TgZ(15,"p-dropdown",58),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.categoryId=n)}),t.YNc(16,B,1,1,"ng-template",53)(17,O,2,3,"ng-template",54),t.qZA()(),t.TgZ(18,"div",59)(19,"div",60)(20,"label",61),t._uU(21,"Price"),t.qZA(),t.TgZ(22,"p-inputNumber",62),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.rate=n)}),t.qZA()(),t.TgZ(23,"div",60)(24,"label",63),t._uU(25,"Quantity"),t.qZA(),t.TgZ(26,"p-inputNumber",64),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.quantity=n)}),t.qZA()()(),t.TgZ(27,"div",50)(28,"label",65),t._uU(29,"Batch"),t.qZA(),t.TgZ(30,"input",66),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.batch=n)}),t.qZA()(),t.TgZ(31,"div",50)(32,"label",67),t._uU(33,"Manufacturing Date"),t.qZA(),t.TgZ(34,"p-calendar",68),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.manufacturingDate=n)}),t.qZA()(),t.TgZ(35,"div",69)(36,"label",70),t._uU(37,"Expiry Date"),t.qZA(),t.TgZ(38,"p-calendar",71),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.stock.expiryDate=n)}),t.qZA()()}if(2&o){const e=t.oxw();t.xp6(3),t.Q6J("ngModel",e.stock.productId)("options",e.productsList),t.xp6(6),t.Q6J("ngModel",e.stock.vendorId)("options",e.vendorsList),t.xp6(6),t.Q6J("ngModel",e.stock.categoryId)("options",e.categoryList),t.xp6(7),t.Q6J("ngModel",e.stock.rate),t.xp6(4),t.Q6J("ngModel",e.stock.quantity),t.xp6(4),t.Q6J("ngModel",e.stock.batch),t.xp6(4),t.Q6J("ngModel",e.stock.manufacturingDate)("showIcon",!0),t.xp6(4),t.Q6J("ngModel",e.stock.expiryDate)("showIcon",!0)}}function H(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"button",73),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.hideDialog())}),t.qZA(),t.TgZ(1,"button",74),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.saveProduct())}),t.qZA()}}function K(o,l){if(1&o&&(t.TgZ(0,"span"),t._uU(1,"Are you sure you want to delete "),t.TgZ(2,"b"),t._uU(3),t.qZA(),t._uU(4,"?"),t.qZA()),2&o){const e=t.oxw();t.xp6(3),t.hij(" ",e.pName,"")}}function j(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"button",75),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.deleteStockDialog=!1)}),t.qZA(),t.TgZ(1,"button",76),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.confirmDelete())}),t.qZA()}}const Y=()=>["productName","vendorName","categoryName","rate","quantity","batch","manufacturingDate","expiryDate","inStock"],V=()=>[10,20,30],I=()=>({width:"450px"});let U=(()=>{class o{constructor(e,i,n,s,m){this.service=e,this.messageService=i,this.productService=n,this.vendorService=s,this.categoryService=m,this.productsList=[],this.vendorsList=[],this.categoryList=[],this.loading=!1,this.stockList=[],this.stock={},this.selectedStocks=[],this.deleteStocksDialog=!1,this.deleteStockDialog=!1,this.submitted=!1,this.stockDialog=!1,this.stockToDelete={},this.cols=[],this.categoryMap={},this.vendorMap={},this.productMap={}}ngOnInit(){this.refreshStockList(),this.cols=[{field:"product",header:"Product"},{field:"price",header:"Price"},{field:"category",header:"Category"},{field:"rating",header:"Reviews"},{field:"inventoryStatus",header:"Status"}],this.productService.getAllProducts().subscribe({next:e=>{this.loading=!1,this.productsList=e.data,this.productsList.forEach(i=>{this.productMap[i.id]=i.productName})},error:e=>{this.loading=!1,this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}}),this.vendorService.getAllVendors().subscribe({next:e=>{this.loading=!1,this.vendorsList=e.data,this.vendorsList.forEach(i=>{this.vendorMap[i.id]=i.vendorName})},error:e=>{this.loading=!1,this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}}),this.categoryService.getAllCategories().subscribe({next:e=>{this.loading=!1,this.categoryList=e.data,this.categoryList.forEach(i=>{this.categoryMap[i.id]=i.categoryName})},error:e=>{this.loading=!1,this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}})}openNew(){this.stock={},this.submitted=!1,this.stockDialog=!0}deleteSelectedStocks(){this.deleteStocksDialog=!0}editStock(e){let i=this.getKeyByValue(e.productName,this.productMap),n=this.getKeyByValue(e.vendorName,this.vendorMap),s=this.getKeyByValue(e.categoryName,this.categoryMap);e.expiryDate&&(e.expiryDate=new Date(e.expiryDate)),e.manufacturingDate&&(e.manufacturingDate=new Date(e?.manufacturingDate)),e.id=e.stockId,e.productId=i,e.vendorId=n,e.categoryId=s,console.log(e),this.stock={...e},this.stockDialog=!0}deleteStock(e){this.deleteStockDialog=!0,this.pName=e.productName,this.stockIdtoDelete=e.stockId}confirmDelete(){this.deleteStockDialog=!1,this.service.StockDelete(this.stockIdtoDelete).subscribe({next:e=>{this.messageService.add(1==e.status?{severity:"success",summary:"Successful",detail:e.message,life:3e3}:{severity:"error",summary:"Error",detail:e.message,life:3e3}),this.refreshStockList()},error:e=>{this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}})}hideDialog(){this.stockDialog=!1,this.submitted=!1}saveProduct(){console.log(this.stock),this.submitted=!0,this.service.StockAdd(this.stock).subscribe({next:e=>{this.loading=!1,this.messageService.add(1==e.status?{severity:"success",summary:"Successful",detail:e.message,life:3e3}:{severity:"error",summary:"Error",detail:e.message,life:3e3}),this.refreshStockList()},error:e=>{this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}}),this.stock={},this.stockDialog=!1}findIndexById(e){let i=-1;for(let n=0;n<this.stockList.length;n++)if(this.stockList[n].id===e){i=n;break}return i}onGlobalFilter(e,i){e.filterGlobal(i.target.value,"contains")}refreshStockList(){this.service.getAllStockWithNames().subscribe({next:e=>{this.stockList=e.data},error:e=>{this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}})}getKeyByValue(e,i){const n=Object.keys(i);for(const s of n)if(i[s]===e)return parseInt(s,10)}static#t=this.\u0275fac=function(i){return new(i||o)(t.Y36(d.q),t.Y36(h.ez),t.Y36(M.M),t.Y36(c.m),t.Y36(T.G))};static#e=this.\u0275cmp=t.Xpm({type:o,selectors:[["app-stock-crud"]],features:[t._Bn([h.ez])],decls:19,vars:22,consts:[[1,"grid"],[1,"col-12"],[1,"card","px-6","py-6"],["styleClass","mb-4"],["pTemplate","left"],["responsiveLayout","scroll","currentPageReportTemplate","Showing {first} to {last} of {totalRecords} entries","selectionMode","multiple","dataKey","id",3,"value","columns","rows","globalFilterFields","paginator","rowsPerPageOptions","showCurrentPageReport","selection","rowHover","selectionChange"],["dt",""],["pTemplate","caption"],["pTemplate","header"],["pTemplate","body"],["header","Stock Details",1,"p-fluid",3,"visible","modal","visibleChange"],["pTemplate","content"],["pTemplate","footer"],["header","Confirm",3,"visible","modal","visibleChange"],[1,"flex","align-items-center","justify-content-center"],[1,"pi","pi-exclamation-triangle","mr-3",2,"font-size","2rem"],[1,"my-2"],["pButton","","pRipple","","label","New","icon","pi pi-plus",1,"p-button-success","mr-2",3,"click"],["pButton","","pRipple","","label","Delete","icon","pi pi-trash",1,"p-button-danger",3,"disabled","click"],[1,"flex","flex-column","md:flex-row","md:justify-content-between","md:align-items-center"],[1,"m-0"],[1,"block","mt-2","md:mt-0","p-input-icon-left"],[1,"pi","pi-search"],["pInputText","","type","text","placeholder","Search by any column...",1,"w-full","sm:w-auto",3,"input"],[2,"width","3rem"],["pSortableColumn","stockId"],["field","stockId"],["pSortableColumn","productName"],["field","productName"],["pSortableColumn","vendorName"],["field","vendorName"],["pSortableColumn","categoryName"],["field","categoryName"],["pSortableColumn","rate"],["field","rate"],["pSortableColumn","quantity"],["field","quantity"],["pSortableColumn","batch"],["field","batch"],["pSortableColumn","manufacturingDate"],["field","manufacturingDate"],["pSortableColumn","expiryDate"],["field","expiryDate"],["pSortableColumn","inStock"],["field","inStock"],[3,"value"],[2,"width","14%","min-width","10rem"],[1,"p-column-title"],[2,"width","14%","min-width","8rem"],[1,"flex"],[1,"field"],["for","productId"],["inputId","productId","optionValue","id","optionLabel","productName","placeholder","Select",3,"ngModel","options","ngModelChange"],["pTemplate","selectedItem"],["pTemplate","item"],["for","vendorId"],["inputId","vendorId","optionValue","id","optionLabel","vendorName","placeholder","Select",3,"ngModel","options","ngModelChange"],["for","categoryId"],["inputId","categoryId","optionValue","id","optionLabel","categoryName","placeholder","Select",3,"ngModel","options","ngModelChange"],[1,"formgrid","grid"],[1,"field","col"],["for","rate"],["id","price","mode","currency","currency","PKR","locale","en-US",3,"ngModel","ngModelChange"],["for","quantity"],["id","quantity",3,"ngModel","ngModelChange"],["for","batch"],["type","text","pInputText","","id","name",3,"ngModel","ngModelChange"],["for","manufacturingDate"],["id","manufacturingDate",3,"ngModel","showIcon","ngModelChange"],[1,"expiryDate"],["for","name"],["id","expiryDate",3,"ngModel","showIcon","ngModelChange"],[4,"ngIf"],["pButton","","pRipple","","label","Cancel","icon","pi pi-times",1,"p-button-text",3,"click"],["pButton","","pRipple","","label","Save","icon","pi pi-check",1,"p-button-text",3,"click"],["pButton","","pRipple","","icon","pi pi-times","label","No",1,"p-button-text",3,"click"],["pButton","","pRipple","","icon","pi pi-check","label","Yes",1,"p-button-text",3,"click"]],template:function(i,n){1&i&&(t.TgZ(0,"div",0)(1,"div",1)(2,"div",2),t._UZ(3,"p-toast"),t.TgZ(4,"p-toolbar",3),t.YNc(5,q,3,1,"ng-template",4),t.qZA(),t.TgZ(6,"p-table",5,6),t.NdJ("selectionChange",function(m){return n.selectedStocks=m}),t.YNc(8,N,6,0,"ng-template",7)(9,D,34,0,"ng-template",8)(10,P,46,14,"ng-template",9),t.qZA()(),t.TgZ(11,"p-dialog",10),t.NdJ("visibleChange",function(m){return n.stockDialog=m}),t.YNc(12,G,39,13,"ng-template",11)(13,H,2,0,"ng-template",12),t.qZA(),t.TgZ(14,"p-dialog",13),t.NdJ("visibleChange",function(m){return n.deleteStockDialog=m}),t.TgZ(15,"div",14),t._UZ(16,"i",15),t.YNc(17,K,5,1,"span"),t.qZA(),t.YNc(18,j,2,0,"ng-template",12),t.qZA()()()),2&i&&(t.xp6(6),t.Q6J("value",n.stockList)("columns",n.cols)("rows",10)("globalFilterFields",t.DdM(18,Y))("paginator",!0)("rowsPerPageOptions",t.DdM(19,V))("showCurrentPageReport",!0)("selection",n.selectedStocks)("rowHover",!0),t.xp6(5),t.Akn(t.DdM(20,I)),t.Q6J("visible",n.stockDialog)("modal",!0),t.xp6(3),t.Akn(t.DdM(21,I)),t.Q6J("visible",n.deleteStockDialog)("modal",!0),t.xp6(3),t.um2(17,n.stock?17:-1))},dependencies:[p.O5,Z.V,h.jx,x.Rn,A.Lt,k.o,u.o,y.FN,g.H,f.Hq,_.Fj,_.JJ,_.On,C.iA,C.lQ,C.fz,C.UA,C.Mo,S.f,p.H9]})}return o})();function $(o,l){1&o&&(t.TgZ(0,"tr")(1,"th"),t._uU(2,"Product Name"),t.qZA(),t.TgZ(3,"th"),t._uU(4,"Requested Quantity"),t.qZA(),t.TgZ(5,"th"),t._uU(6,"Total Price"),t.qZA()())}function z(o,l){if(1&o&&(t.TgZ(0,"tr")(1,"td"),t._uU(2),t.qZA(),t.TgZ(3,"td"),t._uU(4),t.qZA(),t.TgZ(5,"td"),t._uU(6),t.ALo(7,"currency"),t.qZA()()),2&o){const e=l.$implicit;t.xp6(2),t.Oqu(e.productName),t.xp6(2),t.Oqu(e.requestedQuantity),t.xp6(2),t.Oqu(t.gM2(7,3,e.requestedQuantity*e.pricePerUnit,"USD","symbol","1.2-2"))}}const W=()=>({width:"100%"});function X(o,l){if(1&o&&(t.TgZ(0,"div",5)(1,"p-table",16),t.YNc(2,$,7,0,"ng-template",10)(3,z,8,8,"ng-template",11),t.qZA()()),2&o){const e=t.oxw(2);t.xp6(1),t.Akn(t.DdM(3,W)),t.Q6J("value",e.requestList)}}function tt(o,l){if(1&o&&t.YNc(0,X,4,4,"div",15),2&o){const e=t.oxw();t.Q6J("ngIf",e.requestList&&e.requestList.length>0)}}function et(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"div",17)(1,"h5",18),t._uU(2,"Current Items In Stock"),t.qZA(),t.TgZ(3,"span",19),t._UZ(4,"i",20),t.TgZ(5,"input",21),t.NdJ("input",function(n){t.CHM(e);const s=t.oxw(),m=t.MAs(9);return t.KtG(s.onGlobalFilter(m,n))}),t.qZA()()()}}function ot(o,l){1&o&&(t.TgZ(0,"tr")(1,"th",22),t._UZ(2,"p-tableHeaderCheckbox"),t.qZA(),t.TgZ(3,"th",23),t._uU(4,"Product Name "),t._UZ(5,"p-sortIcon",24),t.qZA(),t.TgZ(6,"th",25),t._uU(7,"Product Id "),t._UZ(8,"p-sortIcon",26),t.qZA(),t.TgZ(9,"th",27),t._uU(10,"Price Per Product "),t._UZ(11,"p-sortIcon",28),t.qZA(),t.TgZ(12,"th",29),t._uU(13,"Total Quantity "),t._UZ(14,"p-sortIcon",30),t.qZA()())}function nt(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"tr")(1,"td"),t._UZ(2,"p-tableCheckbox",16),t.qZA(),t.TgZ(3,"td",31)(4,"span",32),t._uU(5,"Product Name"),t.qZA(),t._uU(6),t.qZA(),t.TgZ(7,"td",31)(8,"span",32),t._uU(9,"Product Id"),t.qZA(),t._uU(10),t.qZA(),t.TgZ(11,"td",33)(12,"span",32),t._uU(13,"Price Per Product"),t.qZA(),t._uU(14),t.ALo(15,"currency"),t.qZA(),t.TgZ(16,"td",31)(17,"span",32),t._uU(18,"Total Quantity"),t.qZA(),t._uU(19),t.qZA(),t.TgZ(20,"td")(21,"div",34)(22,"button",35),t.NdJ("click",function(){const s=t.CHM(e).$implicit,m=t.oxw();return t.KtG(m.addToCartList(s))}),t.qZA()()()()}if(2&o){const e=l.$implicit;t.xp6(2),t.Q6J("value",e),t.xp6(4),t.hij(" ",e.productName," "),t.xp6(4),t.hij(" ",e.productId," "),t.xp6(4),t.hij(" ",t.xi3(15,5,e.pricePerUnit,"PKR ")," "),t.xp6(5),t.hij(" ",e.totalQty," ")}}function it(o,l){if(1&o&&(t.TgZ(0,"div",44),t._uU(1),t.qZA()),2&o){const e=t.oxw(2);t.xp6(1),t.hij(" Quantity cannot be greater than ",e.newProductRequest.MaxQuantity,". ")}}function rt(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"div",36)(1,"label",37),t._uU(2,"Product Name"),t.qZA(),t.TgZ(3,"input",38),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.newProductRequest.productName=n)}),t.qZA()(),t.TgZ(4,"div",39)(5,"div",40)(6,"label",41),t._uU(7,"Quantity"),t.qZA(),t.TgZ(8,"p-inputNumber",42),t.NdJ("ngModelChange",function(n){t.CHM(e);const s=t.oxw();return t.KtG(s.newProductRequest.requestedQuantity=n)})("ngModelChange",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.checkQuantity())}),t.qZA(),t.YNc(9,it,2,1,"div",43),t.qZA()()}if(2&o){const e=t.oxw();t.xp6(3),t.Q6J("ngModel",e.newProductRequest.productName),t.xp6(5),t.Q6J("ngModel",e.newProductRequest.requestedQuantity)("styleClass",e.quantityError?"input-error":""),t.xp6(1),t.Q6J("ngIf",e.quantityError)}}function at(o,l){if(1&o){const e=t.EpF();t.TgZ(0,"button",45),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.hideDialog())}),t.qZA(),t.TgZ(1,"button",46),t.NdJ("click",function(){t.CHM(e);const n=t.oxw();return t.KtG(n.saveProduct())}),t.qZA()}if(2&o){const e=t.oxw();t.xp6(1),t.Q6J("disabled",e.quantityError)}}const st=()=>["productName","totalQty","pricePerUnit"],lt=()=>[10,20,30],ct=()=>({width:"450px"});let pt=(()=>{class o{constructor(e,i){this.service=e,this.messageService=i,this.loading=!1,this.stockForUserList=[],this.productsForRequestList=[],this.requestList=[],this.newProductRequest={},this.quantityError=!1,this.selectedStocks=[],this.deleteStocksDialog=!1,this.deleteStockDialog=!1,this.submitted=!1,this.stockDialog=!1,this.cols=[]}ngOnInit(){this.refreshStockList(),this.cols=[{field:"product",header:"Product"},{field:"price",header:"Price"},{field:"category",header:"Category"},{field:"rating",header:"Reviews"},{field:"inventoryStatus",header:"Status"}]}saveData(){this.service.AddRequestList(this.requestList).subscribe({next:e=>{this.loading=!1,this.messageService.add(1==e.status?{severity:"success",summary:"Successful",detail:e.message,life:3e3}:{severity:"error",summary:"Error",detail:e.message,life:3e3}),this.refreshStockList()},error:e=>{this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}}),this.requestList=[]}addToCartList(e){this.newProductRequest.productId=e.productId,this.newProductRequest.productName=e.productName,this.newProductRequest.pricePerUnit=e.pricePerUnit,this.newProductRequest.MaxQuantity=e.totalQty,this.stockDialog=!0}hideDialog(){this.stockDialog=!1,this.submitted=!1}saveProduct(){this.requestList.push(this.newProductRequest),this.newProductRequest={},this.submitted=!0,this.stockDialog=!1}onGlobalFilter(e,i){e.filterGlobal(i.target.value,"contains")}refreshStockList(){this.service.getAllStockForUser().subscribe({next:e=>{this.stockForUserList=e.data},error:e=>{this.messageService.add({severity:"error",summary:"Error",detail:e.message,life:3e3})}})}checkQuantity(){this.quantityError=this.newProductRequest.requestedQuantity>this.newProductRequest.MaxQuantity}static#t=this.\u0275fac=function(i){return new(i||o)(t.Y36(d.q),t.Y36(h.ez))};static#e=this.\u0275cmp=t.Xpm({type:o,selectors:[["app-stockforuser-crud"]],decls:16,vars:17,consts:[[1,"grid"],[1,"col-12"],[1,"card","px-6","py-6"],["styleClass","mb-4"],["pTemplate","left"],[1,"my-2"],["pButton","","pRipple","","label","Place Request","icon","pi pi-plus",1,"p-button-success","mr-2",3,"disabled","click"],["responsiveLayout","scroll","currentPageReportTemplate","Showing {first} to {last} of {totalRecords} entries","selectionMode","multiple","dataKey","id",3,"value","columns","rows","globalFilterFields","paginator","rowsPerPageOptions","showCurrentPageReport","selection","rowHover","selectionChange"],["dt",""],["pTemplate","caption"],["pTemplate","header"],["pTemplate","body"],["header","Add to Cart",1,"p-fluid",3,"visible","modal","visibleChange"],["pTemplate","content"],["pTemplate","footer"],["class","my-2",4,"ngIf"],[3,"value"],[1,"flex","flex-column","md:flex-row","md:justify-content-between","md:align-items-center"],[1,"m-0"],[1,"block","mt-2","md:mt-0","p-input-icon-left"],[1,"pi","pi-search"],["pInputText","","type","text","placeholder","Search by any column...",1,"w-full","sm:w-auto",3,"input"],[2,"width","3rem"],["pSortableColumn","productName"],["field","productName"],["pSortableColumn","productId"],["field","productId"],["pSortableColumn","pricePerUnit"],["field","pricePerUnit"],["pSortableColumn","totalQty"],["field","totalQty"],[2,"width","14%","min-width","10rem"],[1,"p-column-title"],[2,"width","14%","min-width","8rem"],[1,"flex"],["pButton","","pRipple","","icon","pi pi-shopping-cart",1,"p-button-rounded","p-button-success","mr-2",3,"click"],[1,"field"],["for","productName"],["type","text","pInputText","","id","name","disabled","",3,"ngModel","ngModelChange"],[1,"formgrid","grid"],[1,"field","col"],["for","requestedQuantity"],["id","requestedQuantity",3,"ngModel","styleClass","ngModelChange"],["class","error-message","style","color: red;",4,"ngIf"],[1,"error-message",2,"color","red"],["pButton","","pRipple","","label","Cancel","icon","pi pi-times",1,"p-button-text",3,"click"],["pButton","","pRipple","","label","Save","icon","pi pi-check",1,"p-button-text",3,"disabled","click"]],template:function(i,n){1&i&&(t.TgZ(0,"div",0)(1,"div",1)(2,"div",2),t._UZ(3,"p-toast"),t.TgZ(4,"p-toolbar",3),t.YNc(5,tt,1,1,"ng-template",4),t.TgZ(6,"div",5)(7,"button",6),t.NdJ("click",function(){return n.saveData()}),t.qZA()()(),t.TgZ(8,"p-table",7,8),t.NdJ("selectionChange",function(m){return n.selectedStocks=m}),t.YNc(10,et,6,0,"ng-template",9)(11,ot,15,0,"ng-template",10)(12,nt,23,8,"ng-template",11),t.qZA()(),t.TgZ(13,"p-dialog",12),t.NdJ("visibleChange",function(m){return n.stockDialog=m}),t.YNc(14,rt,10,4,"ng-template",13)(15,at,2,1,"ng-template",14),t.qZA()()()),2&i&&(t.xp6(7),t.Q6J("disabled",!n.requestList||0===n.requestList.length),t.xp6(1),t.Q6J("value",n.stockForUserList)("columns",n.cols)("rows",10)("globalFilterFields",t.DdM(14,st))("paginator",!0)("rowsPerPageOptions",t.DdM(15,lt))("showCurrentPageReport",!0)("selection",n.selectedStocks)("rowHover",!0),t.xp6(5),t.Akn(t.DdM(16,ct)),t.Q6J("visible",n.stockDialog)("modal",!0))},dependencies:[p.O5,Z.V,h.jx,x.Rn,k.o,u.o,y.FN,g.H,f.Hq,_.Fj,_.JJ,_.On,C.iA,C.lQ,C.fz,C.UA,C.Mo,p.H9]})}return o})(),ut=(()=>{class o{static#t=this.\u0275fac=function(i){return new(i||o)};static#e=this.\u0275mod=t.oAB({type:o});static#o=this.\u0275inj=t.cJS({imports:[r.Bz.forChild([{path:"create",component:U,data:{title:"Create Stock"}},{path:"create/:id",component:U,data:{title:"Edit Stock"}},{path:"inventory",component:pt,data:{title:"View Stock"}}]),r.Bz]})}return o})();var dt=a(1865);let gt=(()=>{class o{static \u0275fac=function(i){return new(i||o)};static \u0275mod=t.oAB({type:o});static \u0275inj=t.cJS({imports:[p.ez]})}return o})();var mt=a(6022),_t=a(3743);let ht=(()=>{class o{static#t=this.\u0275fac=function(i){return new(i||o)};static#e=this.\u0275mod=t.oAB({type:o});static#o=this.\u0275inj=t.cJS({imports:[p.ez,ut,Z.S,x.L$,dt.cc,A.kW,gt,k.j,mt.Xt,u.V,y.EV,g.T,f.hJ,_.u5,_t.O,C.U$,S._8]})}return o})()},7209:(b,v,a)=>{a.d(v,{q:()=>t});var p=a(553),r=a(5849),h=a(1474);let t=(()=>{class d{constructor(c){this.http=c}getAllStocks(){return this.http.get(`${p.N.apiUrl}/api/StockAPI/GetAllStocks`)}getAllStockWithNames(){return this.http.get(`${p.N.apiUrl}/api/StockAPI/GetAllStockWithNames`)}getStockById(c){return this.http.get(`${p.N.apiUrl}/api/StockAPI/GetProductById/${c}`)}getAllStockForUser(){return this.http.get(`${p.N.apiUrl}/api/StockAPI/GetAllStockForUser`)}AddRequestList(c){return this.http.post(`${p.N.apiUrl}/api/RequestAPI/CreateOrUpdateRequest`,c)}StockAdd(c){return this.http.post(`${p.N.apiUrl}/api/StockAPI/CreateOrUpdateStock`,c)}StockDelete(c){return this.http.delete(`${p.N.apiUrl}/api/StockAPI/DeleteStock/${c}`)}static#t=this.\u0275fac=function(T){return new(T||d)(r.LFG(h.eN))};static#e=this.\u0275prov=r.Yz7({token:d,factory:d.\u0275fac,providedIn:"root"})}return d})()},9720:(b,v,a)=>{a.d(v,{m:()=>t});var p=a(553),r=a(5849),h=a(1474);let t=(()=>{class d{constructor(c){this.http=c}getAllVendors(){return this.http.get(`${p.N.apiUrl}/api/VendorAPI/GetAllVendors`)}getVendorById(c){return this.http.get(`${p.N.apiUrl}/api/VendorAPI/GetVendorById/${c}`)}VendorAdd(c){return this.http.post(`${p.N.apiUrl}/api/VendorAPI/CreateorUpdateVendor`,c)}VendorDelete(c){return this.http.delete(`${p.N.apiUrl}/api/VendorAPI/DeleteVendor/`+c)}static#t=this.\u0275fac=function(T){return new(T||d)(r.LFG(h.eN))};static#e=this.\u0275prov=r.Yz7({token:d,factory:d.\u0275fac,providedIn:"root"})}return d})()},6340:(b,v,a)=>{a.d(v,{V:()=>k,o:()=>A});var p=a(6814),r=a(5849),h=a(5219);function t(u,y){1&u&&r.GkF(0)}function d(u,y){if(1&u&&(r.TgZ(0,"div",4),r.YNc(1,t,1,0,"ng-container",5),r.qZA()),2&u){const g=r.oxw();r.uIk("data-pc-section","start"),r.xp6(1),r.Q6J("ngTemplateOutlet",g.startTemplate)}}function M(u,y){1&u&&r.GkF(0)}function c(u,y){if(1&u&&(r.TgZ(0,"div",6),r.YNc(1,M,1,0,"ng-container",5),r.qZA()),2&u){const g=r.oxw();r.uIk("data-pc-section","center"),r.xp6(1),r.Q6J("ngTemplateOutlet",g.centerTemplate)}}function T(u,y){1&u&&r.GkF(0)}function Z(u,y){if(1&u&&(r.TgZ(0,"div",7),r.YNc(1,T,1,0,"ng-container",5),r.qZA()),2&u){const g=r.oxw();r.uIk("data-pc-section","end"),r.xp6(1),r.Q6J("ngTemplateOutlet",g.endTemplate)}}const x=["*"];let A=(()=>{class u{el;style;styleClass;ariaLabelledBy;templates;startTemplate;endTemplate;centerTemplate;constructor(g){this.el=g}getBlockableElement(){return this.el.nativeElement.children[0]}ngAfterContentInit(){this.templates.forEach(g=>{switch(g.getType()){case"start":case"left":this.startTemplate=g.template;break;case"end":case"right":this.endTemplate=g.template;break;case"center":this.centerTemplate=g.template}})}static \u0275fac=function(f){return new(f||u)(r.Y36(r.SBq))};static \u0275cmp=r.Xpm({type:u,selectors:[["p-toolbar"]],contentQueries:function(f,_,C){if(1&f&&r.Suo(C,h.jx,4),2&f){let S;r.iGM(S=r.CRH())&&(_.templates=S)}},hostAttrs:[1,"p-element"],inputs:{style:"style",styleClass:"styleClass",ariaLabelledBy:"ariaLabelledBy"},ngContentSelectors:x,decls:5,vars:9,consts:[["role","toolbar",3,"ngClass","ngStyle"],["class","p-toolbar-group-left p-toolbar-group-start",4,"ngIf"],["class","p-toolbar-group-center",4,"ngIf"],["class","p-toolbar-group-right p-toolbar-group-end",4,"ngIf"],[1,"p-toolbar-group-left","p-toolbar-group-start"],[4,"ngTemplateOutlet"],[1,"p-toolbar-group-center"],[1,"p-toolbar-group-right","p-toolbar-group-end"]],template:function(f,_){1&f&&(r.F$t(),r.TgZ(0,"div",0),r.Hsn(1),r.YNc(2,d,2,2,"div",1)(3,c,2,2,"div",2)(4,Z,2,2,"div",3),r.qZA()),2&f&&(r.Tol(_.styleClass),r.Q6J("ngClass","p-toolbar p-component")("ngStyle",_.style),r.uIk("aria-labelledby",_.ariaLabelledBy)("data-pc-name","toolbar"),r.xp6(2),r.Q6J("ngIf",_.startTemplate),r.xp6(1),r.Q6J("ngIf",_.centerTemplate),r.xp6(1),r.Q6J("ngIf",_.endTemplate))},dependencies:[p.mk,p.O5,p.tP,p.PC],styles:["@layer primeng{.p-toolbar{display:flex;align-items:center;justify-content:space-between;flex-wrap:wrap}.p-toolbar-group-start,.p-toolbar-group-center,.p-toolbar-group-end,.p-toolbar-group-left,.p-toolbar-group-right{display:flex;align-items:center}}\n"],encapsulation:2,changeDetection:0})}return u})(),k=(()=>{class u{static \u0275fac=function(f){return new(f||u)};static \u0275mod=r.oAB({type:u});static \u0275inj=r.cJS({imports:[p.ez]})}return u})()}}]);