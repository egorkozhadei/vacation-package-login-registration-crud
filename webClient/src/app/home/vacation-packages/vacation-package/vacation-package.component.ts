import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { VacationPackagesService } from '@/_services';

@Component({
  selector: 'app-vacation-package',
  templateUrl: './vacation-package.component.html',
  // styleUrls: ['./vacation-package.component.css']
})
export class VacationPackageComponent implements OnInit {

  constructor(
    public service: VacationPackagesService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();

    this.service.formData = {
      id: 0,
      name: '',
      price: 1
    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0)
      this.addVacationPackage(form);
    else
      this.updateVacationPackage(form)
  }

  addVacationPackage(form: NgForm) {
    this.service.addVacationPackage()
      .subscribe(
        res => {
          console.log(res);
          this.resetForm(form);
          this.toastr.success('Added successfully', 'Vacation Package');
          this.service.getVacationPackages();
        },
        err => {
          console.log(err);
          this.toastr.error(err.error.message, 'Error');
        }
      )
  }

  updateVacationPackage(form: NgForm) {
    this.service.updateVacationPackage()
      .subscribe(
        res => {
          console.log(res);
          this.resetForm(form);
          this.toastr.success('Updated successfully', 'Vacation Package');
          this.service.getVacationPackages();
        },
        err => {
          console.log(err);
          this.toastr.error(err, 'Error');
        }
      )
  }

}
