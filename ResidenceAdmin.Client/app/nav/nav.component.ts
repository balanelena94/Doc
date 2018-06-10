import { Component, OnInit, Input, Output } from '@angular/core';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';


@Component({
	moduleId: module.id,
	selector: 'app-nav-bar',
	templateUrl: './nav.component.html',
	styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

	@Output()
	isUserAuthenticated = this.IsUserAuthenticated();
	@Output()
	userClaims: any;
	title = "Document Generator";
	constructor(private router: Router, private userService: UserService) { }

	ngOnInit() {
		if (this.IsUserAuthenticated()) {
			this.userService.getUserClaims().subscribe((data: any) => {
				this.userClaims = data;

			});
		}
	}

	IsUserAuthenticated() {
		if (localStorage.userToken == undefined) {
			return false;
		}
		return true;
	}

	GetUser() {
		if (this.IsUserAuthenticated()) {
			return this.userService.LoggedInUser.FirstName + " " + this.userService.LoggedInUser.LastName
		}
		return null;
	}

	Logout() {
		localStorage.removeItem('userToken');
		this.router.navigate(['/login']);
	}
}

