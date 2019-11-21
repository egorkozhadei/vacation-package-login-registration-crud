import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { OrdersService } from '@/_services';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  // styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  constructor(
    public service: OrdersService,
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
      price: 1,
      vacationPackageId: 0,
      customerId: 0,
      managerId: 0,
      creationDateTime: '',
      completedDateTime: ''
    };
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id === 0) {
      this.addOrder(form);
    } else {
      this.updateOrder(form);
    }
  }

  addOrder(form: NgForm) {
    this.service.addOrder()
    .subscribe(
      res => {
        console.log(res);
        this.resetForm(form);
        this.toastr.success('Added successfully', 'Order');
        this.service.getOrders();
      },
      err => {
        console.log(err);
        this.toastr.error(err.message, 'Error');
      }
    );
  }

  updateOrder(form: NgForm) {
    this.service.updateOrder()
      .subscribe(
        res => {
          console.log(res);
          this.resetForm(form);
          this.toastr.success('Updated successfully', 'Order');
          this.service.getOrders();
        },
        err => {
          console.log(err);
          this.toastr.error(err.message, 'Error');
        }
      );
  }

}
