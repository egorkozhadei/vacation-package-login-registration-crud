
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { VacationPackagesService } from '@/_services';
import { VacationPackage } from '@/_models';

@Component({
  selector: 'app-vacation-packages',
  templateUrl: './vacation-packages.component.html',
  // styleUrls: ['./vacation-packages.component.css']
})
export class VacationPackagesComponent implements OnInit {

  constructor(
    public service: VacationPackagesService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.service.getVacationPackages();
  }

  editVacationPackage(vp: VacationPackage) {
    this.service.formData = Object.assign({}, vp);
  }

  deleteVacationPackage(id) {
    if (confirm('Are you sure?')) {
    this.service.deleteVacationPackage(id)
      .subscribe(
        res => {
          this.service.getVacationPackages();
          this.toastr.success('Deleted successfully', 'Vacation Package');
        },
        err => {
          console.log(err);
          this.toastr.error(err.message, 'Error');
        }
      );
  }}

}
