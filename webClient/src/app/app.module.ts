import { OrderComponent } from './home/orders/order/order.component';
import { CustomersComponent } from './home/customers/customers.component';
import { OrdersComponent } from './home/orders/orders.component';
import { CustomerComponent } from './home/customers/customer/customer.component';
import { VacationPackageComponent } from './home/vacation-packages/vacation-package/vacation-package.component';
import { VacationPackagesComponent } from './home/vacation-packages/vacation-packages.component';

import { VacationPackagesService } from './_services/vacation-package.service';
import { OrdersService } from './_services/orders.service';
import { ManagerService } from './_services/manager.service';
import { CustomersService } from './_services/customers.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { appRoutingModule } from './app.routing';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { AppComponent } from './app.component';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { AlertComponent } from './_components';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        appRoutingModule,
        FormsModule,
        ToastrModule.forRoot()
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        RegisterComponent,
        AlertComponent,
        CustomerComponent,
        OrdersComponent,
        VacationPackageComponent,
        CustomersComponent,
        OrderComponent,
        VacationPackagesComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        CustomersService,
        ManagerService,
        OrdersService,
        VacationPackagesService

    ],
    bootstrap: [AppComponent]
})
export class AppModule { };