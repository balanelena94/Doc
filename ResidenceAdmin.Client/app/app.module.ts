import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { UserService } from './_services/user.service';
import { EmployeeService } from './_services/employee.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { UserComponent } from './user/user.component';
import { EmployeeComponent } from './employee/employee.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { appRoutes } from './app.routing';
import { AuthGuard } from './auth/auth.guard';
//import { AuthInterceptor } from './auth/auth.interceptor';


@NgModule({
	declarations: [
		AppComponent,
		SignUpComponent,
		UserComponent,
		EmployeeComponent,
		SignInComponent,
		HomeComponent,
		NavComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		HttpClientModule,
		ToastrModule.forRoot(),
		BrowserAnimationsModule,
		RouterModule.forRoot(appRoutes, { useHash: true })
	],
	providers: [UserService, EmployeeService],
	bootstrap: [AppComponent]
})
export class AppModule { }