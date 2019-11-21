import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { OrdersService } from '@/_services';
import { Order } from '@/_models';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  // styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  constructor(
    public service: OrdersService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.service.getOrders();
  }

  editOrder(o: Order) {
    this.service.formData = {
      id: o.id,
      price: o.price,
      vacationPackageId: o.vacationPackage.id,
      managerId: o.manager.id,
      customerId: o.customer.id,
      completedDateTime: o.completedDateTime,
      creationDateTime: o.creationDateTime
    };
  }

  deleteOrder(id) {
    if (confirm('Are you sure?')) {
      this.service.deleteOrder(id)
        .subscribe(
          res => {
            this.service.getOrders();
            this.toastr.success('Deleted successfully', 'Order');
          },
          err => {
            console.log(err);
            this.toastr.error(err.message, 'Error');
          }
        );
    }
  }

}
