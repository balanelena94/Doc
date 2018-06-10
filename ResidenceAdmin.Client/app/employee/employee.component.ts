import { Component, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr'
import { Employee } from '../_models/employee';
import { EmployeeService } from '../_services/employee.service';

@Component({
	moduleId: module.id,

	selector: 'employees',
	templateUrl: './employee.component.html',
	styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
	@Output()
	employees: Array<Employee>;
	constructor(private employeeService: EmployeeService, private toastr: ToastrService) { }

	ngOnInit() {
		this.employeeService.getEmployees().subscribe((data: any) => {
			this.employees = [{
				Cnp: '123355',
				FirstName: 'Ion',
				LastName: 'Ionescu'
			}, {
				Cnp: '234565',
				FirstName: 'Vasile',
				LastName: 'Vasilescu'
			} ]
		});
	}
}