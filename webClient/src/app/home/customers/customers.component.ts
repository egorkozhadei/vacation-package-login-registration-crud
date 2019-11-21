import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomersService } from '@/_services';
import { Customer } from '@/_models';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  // styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  constructor(
    public service: CustomersService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.service.getCustomers();
  }

  editCustomer(c: Customer) {
    this.service.formData = Object.assign({}, c);
  }

  deleteCustomer(id) {
    if (confirm('Are you sure?')) {
    this.service.deleteCustomer(id)
      .subscribe(
        res => {
          this.service.getCustomers();
          this.toastr.success('Deleted successfully', 'Customer');
        },
        err => {
          console.log(err);
        }
      );
  }}


}
