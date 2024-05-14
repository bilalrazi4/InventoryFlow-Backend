"use strict";(self.webpackChunksakai_ng=self.webpackChunksakai_ng||[]).push([[592],{5160:(U,f,i)=>{i.d(f,{f:()=>h});var p=i(5849);let h=(()=>{class c{showValidationMsg(u,e){for(const n in u.controls)if(u.controls.hasOwnProperty(n)){const m=u.controls[n];if(Object.keys(m).includes("controls")&&this.showValidationMsg(u.controls[n],e),m.markAsTouched(),m.invalid&&!e){e=m;let v=document.querySelector(`[formControlName='${this.getName(m,u)}']`);v&&v.scrollIntoView()}}}getName(u,e){for(let n in e.controls)if(u===e.controls[n])return n;return null}getToday(){return(new Date).toISOString().split("T")[0]}static#t=this.\u0275fac=function(e){return new(e||c)};static#e=this.\u0275prov=p.Yz7({token:c,factory:c.\u0275fac,providedIn:"root"})}return c})()},9899:(U,f,i)=>{i.r(f),i.d(f,{Productmodule:()=>F});var p=i(6814),h=i(95),c=i(707),t=i(6916),u=i(228),e=i(5849),n=i(9697),m=i(5160),v=i(5219);function y(l,d){1&l&&(e.TgZ(0,"tr")(1,"th",6),e._uU(2,"Produt No."),e.qZA(),e.TgZ(3,"th",6),e._uU(4,"Name"),e.qZA(),e.TgZ(5,"th",6),e._uU(6,"Action"),e.qZA()())}const x=l=>["/main/product/create",l];function Z(l,d){if(1&l){const r=e.EpF();e.TgZ(0,"tr")(1,"td"),e._uU(2),e.qZA(),e.TgZ(3,"td"),e._uU(4),e.qZA(),e.TgZ(5,"td")(6,"div",7),e._UZ(7,"button",8),e.TgZ(8,"button",9),e.NdJ("click",function(){const a=e.CHM(r).$implicit,g=e.oxw();return e.KtG(g.deleteProduct(a.id))}),e.qZA()()()()}if(2&l){const r=d.$implicit;e.xp6(2),e.Oqu(r.id),e.xp6(2),e.Oqu(r.productName),e.xp6(3),e.Q6J("routerLink",e.VKq(3,x,r.id))}}const T=()=>({"min-width":"60rem"});let b=(()=>{class l{constructor(r,o,s,a,g){this.fb=r,this.service=o,this.utilService=s,this.route=a,this.messageService=g,this.loading=!1,this.singleProduct={},this.productList=[]}ngOnInit(){this.productForm=this.fb.group({productName:["",[h.kI.required]],id:null}),this.subscription=this.route.params.subscribe(r=>{this.productId=+r.id,this.productId&&this.GetProductById()}),this.service.getAllProducts().subscribe({next:r=>{this.loading=!1,this.productList=r.data},error:r=>{this.loading=!1}})}submitProductForm(){this.productForm.invalid?this.utilService.showValidationMsg(this.productForm):this.productList.some(o=>o.productName.toLowerCase()==this.productForm.value.productName.toLowerCase())?this.messageService.add({key:"tst",severity:"error",summary:"Product already exists",detail:"Product name already exists"}):this.service.ProductAdd(this.productForm.value).subscribe({next:o=>{this.loading=!1,this.productForm.reset(),this.refreshProductList(),this.messageService.add(this.productId?{key:"tst",severity:"success",summary:"Successfully Updated",detail:"Product updated"}:{key:"tst",severity:"success",summary:"Successfully Created",detail:"Product created"})},error:o=>{this.loading=!1}})}GetProductById(){this.service.getProductById(this.productId).subscribe({next:r=>{this.loading=!1,this.singleProduct=r.data,this.productForm.patchValue(this.singleProduct)},error:r=>{this.loading=!1}})}deleteProduct(r){this.service.ProductDelete(r).subscribe(),this.refreshProductList()}refreshProductList(){this.loading=!0,this.service.getAllProducts().subscribe({next:r=>{this.loading=!1,this.productList=r.data},error:r=>{this.loading=!1}})}static#t=this.\u0275fac=function(o){return new(o||l)(e.Y36(h.qu),e.Y36(n.M),e.Y36(m.f),e.Y36(u.gz),e.Y36(v.ez))};static#e=this.\u0275cmp=e.Xpm({type:l,selectors:[["app-product-crud"]],decls:8,vars:3,consts:[[1,"grid"],[1,"col-9","lg:col-9","xl:col-9","md:col-9"],[1,"card","mb-0"],[3,"value","tableStyle"],["pTemplate","header"],["pTemplate","body"],["scope","col"],[1,"flex"],["pButton","","pRipple","","icon","pi pi-pencil",1,"p-button-rounded","p-button-success","mr-2",3,"routerLink"],["pButton","","pRipple","","icon","pi pi-trash",1,"p-button-rounded","p-button-warning",3,"click"]],template:function(o,s){1&o&&(e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"h5"),e._uU(4,"List of Products"),e.qZA(),e.TgZ(5,"p-table",3),e.YNc(6,y,7,0,"ng-template",4)(7,Z,9,5,"ng-template",5),e.qZA()()()()),2&o&&(e.xp6(5),e.Q6J("value",s.productList)("tableStyle",e.DdM(2,T)))},dependencies:[c.Hq,v.jx,t.iA,u.rH]})}return l})(),I=(()=>{class l{static#t=this.\u0275fac=function(o){return new(o||l)};static#e=this.\u0275mod=e.oAB({type:l});static#r=this.\u0275inj=e.cJS({imports:[u.Bz.forChild([{path:"create",component:b,data:{title:"Create Product"}},{path:"create/:id",component:b,data:{title:"Edit Product"}}]),u.Bz]})}return l})();var P=i(4104),C=i(9445);let F=(()=>{class l{static#t=this.\u0275fac=function(o){return new(o||l)};static#e=this.\u0275mod=e.oAB({type:l});static#r=this.\u0275inj=e.cJS({providers:[n.M],imports:[p.ez,h.u5,h.UX,c.hJ,t.U$,I,C.$,P.EV]})}return l})()},9342:(U,f,i)=>{i.r(f),i.d(f,{CategoriesModule:()=>d});var p=i(6814),h=i(228),c=i(95),t=i(5849),u=i(8225),e=i(5160),n=i(5219),m=i(707),v=i(6916),y=i(4104);function x(r,o){if(1&r){const s=t.EpF();t.TgZ(0,"button",14),t.NdJ("click",function(){t.CHM(s);const g=t.oxw();return t.KtG(g.submitCategoryForm())}),t._uU(1,"Submit"),t.qZA()}}function Z(r,o){if(1&r){const s=t.EpF();t.TgZ(0,"button",14),t.NdJ("click",function(){t.CHM(s);const g=t.oxw();return t.KtG(g.submitCategoryForm())}),t._uU(1,"Update"),t.qZA()}}function T(r,o){1&r&&(t.TgZ(0,"tr")(1,"th",15),t._uU(2,"Category No."),t.qZA(),t.TgZ(3,"th",15),t._uU(4,"Name"),t.qZA(),t.TgZ(5,"th",15),t._uU(6,"Action"),t.qZA()())}const b=r=>["/main/categories/create",r];function I(r,o){if(1&r){const s=t.EpF();t.TgZ(0,"tr")(1,"td"),t._uU(2),t.qZA(),t.TgZ(3,"td"),t._uU(4),t.qZA(),t.TgZ(5,"td")(6,"div",16),t._UZ(7,"button",17),t.TgZ(8,"button",18),t.NdJ("click",function(){const A=t.CHM(s).$implicit,N=t.oxw();return t.KtG(N.deleteCategory(A.id))}),t.qZA()()()()}if(2&r){const s=o.$implicit;t.xp6(2),t.Oqu(s.id),t.xp6(2),t.Oqu(s.categoryName),t.xp6(3),t.Q6J("routerLink",t.VKq(3,b,s.id))}}const P=()=>({"min-width":"60rem"});let C=(()=>{class r{constructor(s,a,g,A,N){this.fb=s,this.service=a,this.utilService=g,this.route=A,this.messageService=N,this.loading=!1,this.singleCategory={},this.categoryList=[]}ngOnInit(){this.categoryForm=this.fb.group({categoryName:["",[c.kI.required]],id:null}),this.subscription=this.route.params.subscribe(s=>{this.categoryId=+s.id,this.categoryId&&this.GetCategoryById()}),this.service.getAllCategories().subscribe({next:s=>{this.loading=!1,this.categoryList=s.data},error:s=>{this.loading=!1}})}submitCategoryForm(){this.categoryForm.invalid?this.utilService.showValidationMsg(this.categoryForm):this.categoryList.some(a=>a.categoryName.toLowerCase()==this.categoryForm.value.categoryName.toLowerCase())?this.messageService.add({key:"tst",severity:"error",summary:"Category already exists",detail:"Category name already exists"}):this.service.CategoryrAdd(this.categoryForm.value).subscribe({next:a=>{this.loading=!1,this.categoryForm.reset(),this.refreshCategoryList(),this.messageService.add(this.categoryId?{key:"tst",severity:"success",summary:"Successfully Updated",detail:"Category updated"}:{key:"tst",severity:"success",summary:"Successfully Created",detail:"Category created"})},error:a=>{this.loading=!1}})}GetCategoryById(){this.service.getCategoryById(this.categoryId).subscribe({next:s=>{this.loading=!1,this.singleCategory=s.data,this.categoryForm.patchValue(this.singleCategory)},error:s=>{this.loading=!1}})}deleteCategory(s){this.service.CategoryDelete(s).subscribe(),this.refreshCategoryList()}refreshCategoryList(){this.loading=!0,this.service.getAllCategories().subscribe({next:s=>{this.loading=!1,this.categoryList=s.data},error:s=>{this.loading=!1}})}static#t=this.\u0275fac=function(a){return new(a||r)(t.Y36(c.qu),t.Y36(u.G),t.Y36(e.f),t.Y36(h.gz),t.Y36(n.ez))};static#e=this.\u0275cmp=t.Xpm({type:r,selectors:[["app-categories-crud"]],decls:18,vars:6,consts:[[1,"grid"],[1,"col-3","lg:col-3","xl:col-3","md:col-3"],[3,"formGroup"],[1,"card","p-fluid"],[1,"field"],["htmlfor","CategoryName"],["formControlName","categoryName","type","text",1,"p-inputtext","p-component","p-element"],["key","tst"],["pButton","","pRipple","",3,"click",4,"ngIf"],[1,"col-9","lg:col-9","xl:col-9","md:col-9"],[1,"card","mb-0"],[3,"value","tableStyle"],["pTemplate","header"],["pTemplate","body"],["pButton","","pRipple","",3,"click"],["scope","col"],[1,"flex"],["pButton","","pRipple","","icon","pi pi-pencil",1,"p-button-rounded","p-button-success","mr-2",3,"routerLink"],["pButton","","pRipple","","icon","pi pi-trash",1,"p-button-rounded","p-button-warning",3,"click"]],template:function(a,g){1&a&&(t.TgZ(0,"div",0)(1,"div",1)(2,"form",2)(3,"div",3)(4,"div",4)(5,"label",5),t._uU(6,"Name"),t.qZA(),t._UZ(7,"input",6),t.qZA(),t._UZ(8,"p-toast",7),t.YNc(9,x,2,0,"button",8)(10,Z,2,0,"button",8),t.qZA()()(),t.TgZ(11,"div",9)(12,"div",10)(13,"h5"),t._uU(14,"List of Categories"),t.qZA(),t.TgZ(15,"p-table",11),t.YNc(16,T,7,0,"ng-template",12)(17,I,9,5,"ng-template",13),t.qZA()()()()),2&a&&(t.xp6(2),t.Q6J("formGroup",g.categoryForm),t.xp6(7),t.Q6J("ngIf",!g.categoryId),t.xp6(1),t.Q6J("ngIf",g.categoryId),t.xp6(5),t.Q6J("value",g.categoryList)("tableStyle",t.DdM(5,P)))},dependencies:[p.O5,h.rH,c._Y,c.Fj,c.JJ,c.JL,c.sg,c.u,m.Hq,n.jx,v.iA,y.FN]})}return r})(),l=(()=>{class r{static#t=this.\u0275fac=function(a){return new(a||r)};static#e=this.\u0275mod=t.oAB({type:r});static#r=this.\u0275inj=t.cJS({imports:[h.Bz.forChild([{path:"create",component:C,data:{title:"Create Category"}},{path:"create/:id",component:C,data:{title:"Edit Category"}}]),h.Bz]})}return r})(),d=(()=>{class r{static#t=this.\u0275fac=function(a){return new(a||r)};static#e=this.\u0275mod=t.oAB({type:r});static#r=this.\u0275inj=t.cJS({imports:[p.ez,l,c.u5,c.UX,m.hJ,v.U$,y.EV]})}return r})()},1358:(U,f,i)=>{i.d(f,{s:()=>t});var p=i(553),h=i(5849),c=i(1474);let t=(()=>{class u{constructor(n){this.http=n}GetAllPendingRequests(){return this.http.get(`${p.N.apiUrl}/api/RequestAPI/GetAllPendingRequests`)}GetAllApprovedRequests(){return this.http.get(`${p.N.apiUrl}/api/RequestAPI/GetAllApprovedRequests`)}GetAllRejectedRequests(){return this.http.get(`${p.N.apiUrl}/api/RequestAPI/GetAllRejectedRequests`)}GetAllRequestsForUser(){return this.http.get(`${p.N.apiUrl}/api/RequestAPI/GetAllRequestsListForUser`)}GetInvoiceAgainstTheRequest(n){return this.http.post(`${p.N.apiUrl}/api/RequestAPI/GetInvoiceAgainstTheApprovedRequest`,n)}GetPendingRequestsDetailList(n){return this.http.get(`${p.N.apiUrl}/api/RequestAPI/GetPendingRequestsDetailList/`+n)}AcceptApprovedRequest(n){return this.http.get(`${p.N.apiUrl}/api/RequestAPI/AcceptApprovedRequest/`+n)}GetChequeImageAndDetailForTheRequest(n){return this.http.get(`${p.N.apiUrl}/api/RequestAPI/GetImageAndChequeDetails/`+n)}ApprovePendingRequest(n){return this.http.post(`${p.N.apiUrl}/api/RequestAPI/ApprovePendingRequest`,n)}RejectPendingRequest(n,m){return this.http.post(`${p.N.apiUrl}/api/RequestAPI/RejectPendingRequest/${m}`,n)}GeneratePdf(n,m){const v=encodeURIComponent(JSON.stringify(m));return this.http.get(`${p.N.apiUrl}/api/RequestAPI/GeneratePDFForApprovedRequest/${n}/${v}`)}UploadImage(n,m,v){return this.http.post(`${p.N.apiUrl}/api/RequestAPI/UploadImage/${m}/${v}`,n)}static#t=this.\u0275fac=function(m){return new(m||u)(h.LFG(c.eN))};static#e=this.\u0275prov=h.Yz7({token:u,factory:u.\u0275fac,providedIn:"root"})}return u})()},282:(U,f,i)=>{i.r(f),i.d(f,{VendorsModule:()=>l});var p=i(6814),h=i(228),c=i(95),t=i(5849),u=i(9720),e=i(5160),n=i(5219),m=i(707),v=i(6916),y=i(4104);function x(d,r){if(1&d){const o=t.EpF();t.TgZ(0,"button",14),t.NdJ("click",function(){t.CHM(o);const a=t.oxw();return t.KtG(a.submitVendorForm())}),t._uU(1,"Submit"),t.qZA()}}function Z(d,r){if(1&d){const o=t.EpF();t.TgZ(0,"button",14),t.NdJ("click",function(){t.CHM(o);const a=t.oxw();return t.KtG(a.submitVendorForm())}),t._uU(1,"Update"),t.qZA()}}function T(d,r){1&d&&(t.TgZ(0,"tr")(1,"th",15),t._uU(2,"Vendor No."),t.qZA(),t.TgZ(3,"th",15),t._uU(4,"Name"),t.qZA(),t.TgZ(5,"th",15),t._uU(6,"Action"),t.qZA()())}const b=d=>["/main/vendor/create",d];function I(d,r){if(1&d){const o=t.EpF();t.TgZ(0,"tr")(1,"td"),t._uU(2),t.qZA(),t.TgZ(3,"td"),t._uU(4),t.qZA(),t.TgZ(5,"td")(6,"div",16),t._UZ(7,"button",17),t.TgZ(8,"button",18),t.NdJ("click",function(){const g=t.CHM(o).$implicit,A=t.oxw();return t.KtG(A.deleteVendor(g.id))}),t.qZA()()()()}if(2&d){const o=r.$implicit;t.xp6(2),t.Oqu(o.id),t.xp6(2),t.Oqu(o.vendorName),t.xp6(3),t.Q6J("routerLink",t.VKq(3,b,o.id))}}const P=()=>({"min-width":"60rem"});let C=(()=>{class d{constructor(o,s,a,g,A){this.fb=o,this.service=s,this.utilService=a,this.route=g,this.messageService=A,this.loading=!1,this.singleVendor={},this.vendorList=[]}ngOnInit(){this.vendorForm=this.fb.group({vendorName:["",[c.kI.required]],id:null}),this.subscription=this.route.params.subscribe(o=>{this.vendorId=+o.id,this.vendorId&&this.GetVendorById()}),this.service.getAllVendors().subscribe({next:o=>{this.loading=!1,this.vendorList=o.data},error:o=>{this.loading=!1}})}submitVendorForm(){this.vendorForm.invalid?this.utilService.showValidationMsg(this.vendorForm):this.vendorList.some(s=>s.vendorName.toLowerCase()==this.vendorForm.value.vendorName.toLowerCase())?this.messageService.add({key:"tst",severity:"error",summary:"Vendor already exists",detail:"Vendor name already exists"}):this.service.VendorAdd(this.vendorForm.value).subscribe({next:s=>{this.loading=!1,this.vendorForm.reset(),this.refreshVendorList(),this.messageService.add(this.vendorId?{key:"tst",severity:"success",summary:"Successfully Updated",detail:"Vendor updated"}:{key:"tst",severity:"success",summary:"Successfully Created",detail:"Vendor created"})},error:s=>{this.loading=!1}})}GetVendorById(){this.service.getVendorById(this.vendorId).subscribe({next:o=>{this.loading=!1,this.singleVendor=o.data,this.vendorForm.patchValue(this.singleVendor)},error:o=>{this.loading=!1}})}deleteVendor(o){this.service.VendorDelete(o).subscribe(),this.refreshVendorList()}refreshVendorList(){this.loading=!0,this.service.getAllVendors().subscribe({next:o=>{this.loading=!1,this.vendorList=o.data},error:o=>{this.loading=!1}})}static#t=this.\u0275fac=function(s){return new(s||d)(t.Y36(c.qu),t.Y36(u.m),t.Y36(e.f),t.Y36(h.gz),t.Y36(n.ez))};static#e=this.\u0275cmp=t.Xpm({type:d,selectors:[["app-vendors-crud"]],decls:18,vars:6,consts:[[1,"grid"],[1,"col-3","lg:col-3","xl:col-3","md:col-3"],[3,"formGroup"],[1,"card","p-fluid"],[1,"field"],["htmlfor","VendorName"],["formControlName","vendorName","type","text",1,"p-inputtext","p-component","p-element"],["key","tst"],["pButton","","pRipple","",3,"click",4,"ngIf"],[1,"col-9","lg:col-9","xl:col-9","md:col-9"],[1,"card","mb-0"],[3,"value","tableStyle"],["pTemplate","header"],["pTemplate","body"],["pButton","","pRipple","",3,"click"],["scope","col"],[1,"flex"],["pButton","","pRipple","","icon","pi pi-pencil",1,"p-button-rounded","p-button-success","mr-2",3,"routerLink"],["pButton","","pRipple","","icon","pi pi-trash",1,"p-button-rounded","p-button-warning",3,"click"]],template:function(s,a){1&s&&(t.TgZ(0,"div",0)(1,"div",1)(2,"form",2)(3,"div",3)(4,"div",4)(5,"label",5),t._uU(6,"Name"),t.qZA(),t._UZ(7,"input",6),t.qZA(),t._UZ(8,"p-toast",7),t.YNc(9,x,2,0,"button",8)(10,Z,2,0,"button",8),t.qZA()()(),t.TgZ(11,"div",9)(12,"div",10)(13,"h5"),t._uU(14,"List of Vendors"),t.qZA(),t.TgZ(15,"p-table",11),t.YNc(16,T,7,0,"ng-template",12)(17,I,9,5,"ng-template",13),t.qZA()()()()),2&s&&(t.xp6(2),t.Q6J("formGroup",a.vendorForm),t.xp6(7),t.Q6J("ngIf",!a.vendorId),t.xp6(1),t.Q6J("ngIf",a.vendorId),t.xp6(5),t.Q6J("value",a.vendorList)("tableStyle",t.DdM(5,P)))},dependencies:[p.O5,h.rH,c._Y,c.Fj,c.JJ,c.JL,c.sg,c.u,m.Hq,n.jx,v.iA,y.FN]})}return d})(),F=(()=>{class d{static#t=this.\u0275fac=function(s){return new(s||d)};static#e=this.\u0275mod=t.oAB({type:d});static#r=this.\u0275inj=t.cJS({imports:[h.Bz.forChild([{path:"create",component:C,data:{title:"Create Vendor"}},{path:"create/:id",component:C,data:{title:"Edit Vendor"}}]),h.Bz]})}return d})(),l=(()=>{class d{static#t=this.\u0275fac=function(s){return new(s||d)};static#e=this.\u0275mod=t.oAB({type:d});static#r=this.\u0275inj=t.cJS({providers:[u.m],imports:[p.ez,F,c.u5,c.UX,m.hJ,v.U$,y.EV]})}return d})()}}]);