
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CustomersService } from '@/_services';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  // styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(
    public service: CustomersService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }

    this.service.formData = {
      id: 0,
      fullName: '',
      phoneNumber: '',
      email: ''
    };
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id === 0) {
      this.addCustomer(form);
    } else {
      this.updateCustomer(form);
    }
  }

  addCustomer(form: NgForm) {
    this.service.addCustomer()
      .subscribe(
        res => {
          console.log(res);
          this.resetForm(form);
          this.toastr.success('Added successfully', 'Customer');
          this.service.getCustomers();
        },
        err => {
          console.log(err);
          this.toastr.error(err.error.message, 'Error');
        }
      );
  }

  updateCustomer(form: NgForm) {
    this.service.updateCustomer()
      .subscribe(
        res => {
          console.log(res);
          this.resetForm(form);
          this.toastr.success('Updated successfully', 'Customer');
          this.service.getCustomers();
        },
        err => {
          console.log(err);
          this.toastr.error(err.message, 'Error');
        }
      );
  }
}
