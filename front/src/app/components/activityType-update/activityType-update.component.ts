import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,Validators,FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivityTypeService } from 'src/app/services/activityTypeService/activityType.service';
import { ActivityType } from 'src/app/models/activityType'
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-activityType-update',
  templateUrl: './activityType-update.component.html',
  styleUrls: ['./activityType-update.component.css']
})
export class ActivityTypeUpdateComponent implements OnInit {
  activityTypeUpdateForm:FormGroup
  activityTypeDetails: ActivityType;
  constructor(private activityTypeService:ActivityTypeService,private toastrService:ToastrService,private formBuilder:FormBuilder, private activatedRoute: ActivatedRoute) { }


  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.getActivityTypeDetails(params['activityTypeId']);
    });
  }

  createActivityTypeUpdateForm() {
    this.activityTypeUpdateForm = this.formBuilder.group({
      activityTypeId: [this.activityTypeDetails.activityTypeId, Validators.required],
      activityTypeName: [this.activityTypeDetails.activityTypeName, Validators.required],
    });
  }

  getActivityTypeDetails(activityTypeId: number) {
    this.activityTypeService.getById(activityTypeId).subscribe((response) => {
      this.activityTypeDetails = response.data[0];
      this.createActivityTypeUpdateForm();
    });
  }

  
  update() {
    if (this.activityTypeUpdateForm.valid) {
      let activityTypeModel = Object.assign({}, this.activityTypeUpdateForm.value);
      this.activityTypeService.update(activityTypeModel).subscribe(
        (response) => {
          
          this.toastrService.success(response.message, 'Successfull');
        },
        responseError=>{
          this.toastrService.error(responseError.error)
        }
       
      );
    } else {
      this.toastrService.error('Form is missing', 'Warning');
    }
  }
  

}
