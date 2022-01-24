import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ActivityType } from 'src/app/models/activityType';
import { ActivityDetail } from 'src/app/models/activityDetail';
import { PriceType } from 'src/app/models/priceType';
import { ActivityTypeService } from 'src/app/services/activityTypeService/activityType.service';
import { ActivityService } from 'src/app/services/activityService/activity.service';
import { IsFreeService } from 'src/app/services/isFreeService/isFree.service';

@Component({
  selector: 'app-activity-update',
  templateUrl: './activity-update.component.html',
  styleUrls: ['./activity-update.component.css'],
})
export class ActivityUpdateComponent implements OnInit {
  activityDetails: ActivityDetail;
  activityTypes: ActivityType[];
  priceTypes: PriceType[];
  activityUpdateForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private activityService: ActivityService,
    private activityTypeService: ActivityTypeService,
    private isFreeService: IsFreeService,
    private toastrService: ToastrService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params:any) => {
      this.getActivityById(params['id']);
      this.getIsFrees();
      this.getActivityTypes();
    });
  }

  getActivityById(id: number) {
    this.activityService.getById(id).subscribe((response) => {
      this.activityDetails = response.data[0];
      this.createActivityUpdateForm();
    });
  }

  getActivityTypes() {
    this.activityTypeService.getActivityTypes().subscribe((response) => {
      this.activityTypes = response.data;
    });
  }

  getIsFrees() {
    this.isFreeService.getIsFrees().subscribe((response) => {
      this.priceTypes = response.data;
    });
  }

  createActivityUpdateForm() {
    this.activityUpdateForm = this.formBuilder.group({
      id: [this.activityDetails.id, Validators.required],
      activityTypeId: [this.activityDetails.activityTypeId, Validators.required],
      priceTypeId: [this.activityDetails.priceTypeId, Validators.required],
      activityName: [this.activityDetails.activityName, Validators.required],
      price: [this.activityDetails.price, Validators.required],
      activityLocation: [this.activityDetails.activityLocation, Validators.required],
      description: [this.activityDetails.description, Validators.required],
      activityDate: [this.activityDetails.activityDate, Validators.required],
      insertUserId: [this.activityDetails.insertUserId]
    });
  }

  update() {
    if (this.activityUpdateForm.valid) {

      let activityModel = Object.assign({}, this.activityUpdateForm.value);
      this.activityService.update(activityModel).subscribe(
        (response) => {
          this.toastrService.success(response.message, 'Successful');
        },
        (responseError) => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (
              let i = 0;
              i < responseError.error.ValidationErrors.length;
              i++
            ) {
              this.toastrService.error(
                responseError.error.ValidationErrors[i].ErrorMessage,
                'Validation Error'
              );
            }
          }
        }
      );
    } else {
      this.toastrService.error('The form is missing.', 'Attention!');
    }
  }
}
