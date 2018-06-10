import { Component, OnInit, Output , Input} from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr'
import { Employee } from '../_models/employee';
import { EmployeeService } from '../_services/employee.service';

@Component({
	moduleId: module.id,

	selector: 'employee',
	templateUrl: './newemployee.component.html',
	styleUrls: ['./newemployee.component.css']
})
export class NewEmployeeComponent implements OnInit {
	ngOnInit(): void {
		throw new Error("Method not implemented.");
	  
		private _isOpen: boolean = false;


	@Input()
	set isOpen(value: boolean) {
		this._isOpen = value;
		if (value) {
			this.accordion.closeOthers(this);
		}
	}

	toggleOpen(event: MouseEvent): void {
		event.preventDefault();
		this.isOpen = !this.isOpen;
	}
}