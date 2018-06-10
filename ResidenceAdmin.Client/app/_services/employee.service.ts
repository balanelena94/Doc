import { Injectable, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';


@Injectable()
export class EmployeeService {
	readonly rootUrl = 'http://localhost:1234/DocGenerator.Api';

	constructor(private http: HttpClient) { }

	getEmployees() {
		return this.http.get(this.rootUrl + '/api/GetEmployees');
	}
}