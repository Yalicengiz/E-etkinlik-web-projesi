import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivityTypeService } from 'src/app/services/activityTypeService/activityType.service';

@Component({
  selector: 'app-activityType-add',
  templateUrl: './activityType-add.component.html',
  styleUrls: ['./activityType-add.component.css'],
})
export class ActivityTypeAddComponent implements OnInit {
  activityTypeAddForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private activityTypeService: ActivityTypeService,
    private toastrService: ToastrService,
    private router:Router
  ) {}

  ngOnInit(): void {
    this.createActivityTypeAddForm();
  }

  createActivityTypeAddForm() {
    this.activityTypeAddForm = this.formBuilder.group({
      activityTypeName: ['', Validators.required],
    });
  }

  add() {
    if (this.activityTypeAddForm.valid) {
      let activityTypeModel = Object.assign({}, this.activityTypeAddForm.value);
      this.activityTypeService.add(activityTypeModel).subscribe(response=>{
        console.log(response)
        this.toastrService.success("Etkinlik Tipi eklendi")},responseError=>
        {
          if(responseError.error.Errors>0){

             this.toastrService.error(responseError.error.Errors.ErrorMessage,"Doğrulama hatası")
           }


          }

      );
      this.router.navigateByUrl("")

    } else {
      this.toastrService.error('form eksik!');
    }
  }
}
