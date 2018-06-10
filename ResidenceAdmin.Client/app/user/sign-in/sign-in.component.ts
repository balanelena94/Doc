import { Component, OnInit } from '@angular/core';
import { UserService } from '../../_services/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
	moduleId: module.id,
	selector: 'app-sign-in',
	templateUrl: './sign-in.component.html',
	styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
	isLoginError: boolean = false;
	constructor(private userService: UserService, private router: Router) { }

	ngOnInit() {
	}

	OnSubmit(userName: any, password: any) {
		this.userService.userAuthentication(userName, password).subscribe((data: any) => {
			localStorage.setItem('userToken', data.access_token);
			this.userService.setLoggedInUser();
			this.router.navigate(['/home']);
		},
			(err: HttpErrorResponse) => {
				this.isLoginError = true;
			});
	}

}