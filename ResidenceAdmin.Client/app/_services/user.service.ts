import { Injectable, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from '../_models/user';

@Injectable()
export class UserService {
	readonly rootUrl = 'http://localhost:1234/DocGenerator.Api';
	@Output()
	LoggedInUser: User;
	constructor(private http: HttpClient) { }

	registerUser(user: User) {
		const body: User = {
			UserName: user.UserName,
			Password: user.Password,
			Email: user.Email,
			FirstName: user.FirstName,
			LastName: user.LastName
		}
		var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
		return this.http.post(this.rootUrl + '/api/User/Register', body, { headers: reqHeader });
	}

	userAuthentication(userName: any, password:  any) {
		var data = "username=" + userName + "&password=" + password + "&grant_type=password";
		var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
		return this.http.post(this.rootUrl + '/token', data, { headers: reqHeader });
	}

	getUserClaims() {
		return this.http.get(this.rootUrl + '/api/GetUserClaims');
	}
	getUser() {
		return this.http.get(this.rootUrl + '/api/GetUser');
	}

	setLoggedInUser() {
		
		 this.http.get(this.rootUrl + '/api/GetUser').subscribe((data: any) => {
			 this.LoggedInUser = data;
		});
	}
}