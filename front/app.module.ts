import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatSelectModule } from '@angular/material/select';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './src/app/app.component';
import { ActivityComponent } from './src/app/components/activity/activity.component';
import { NavbarComponent } from './src/app/components/navbar/navbar.component';
import { ActivityTypeComponent } from './src/app/components/activityType/activityType.component';
import { CustomerComponent } from './src/app/components/customer/customer.component';
import { JoinComponent } from './src/app/components/join/join.component';
import { IsFreeComponent } from './src/app/components/isFree/isFree.component';
import { ActivityDetailComponent } from './src/app/components/activity-detail/activity-detail.component';
import { VatAddedPipe } from './src/app/pipes/vat-added.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FilterPipePipe } from './src/app/pipes/filter-pipe.pipe';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CartSummaryComponent } from './src/app/components/cart-summary/cart-summary.component';
import { ActivityTypeFilterPipe } from './src/app/pipes/activityType-filter.pipe';
import { IsFreeFilterPipe } from './src/app/pipes/isFree-filter.pipe';
import { ActivityTypeAddComponent } from './src/app/components/activityType-add/activityType-add.component';
import { IsFreeAddComponent } from './src/app/components/isFree-add/isFree-add.component';
import { ActivityAddComponent } from './src/app/components/activity-add/activity-add.component';
import { ActivityTypeUpdateComponent } from './src/app/components/activityType-update/activityType-update.component';
import { IsFreeUpdateComponent } from './src/app/components/isFree-update/isFree-update.component';
import { ActivityUpdateComponent } from './src/app/components/activity-update/activity-update.component';
import { LoginComponent } from './src/app/components/login/login.component';
import { AuthInterceptor } from 'src/app/interceptors/auth.interceptor';
import { RegisterComponent } from './src/app/components/register/register.component';
import { ValidateEqualModule } from 'ng-validate-equal';
import { AdminComponent } from './src/app/components/admin/admin.component';
import { ProfileComponent } from './src/app/components/profile/profile.component';
import { SuperuseraddComponent } from './src/app/components/superuseradd/superuseradd.component';

@NgModule({
  declarations: [
    AppComponent,
    ActivityComponent,
    NavbarComponent,
    ActivityTypeComponent,
    CustomerComponent,
    JoinComponent,
    IsFreeComponent,
    ActivityDetailComponent,
    VatAddedPipe,
    FilterPipePipe,
    CartSummaryComponent,
    ActivityTypeFilterPipe,
    IsFreeFilterPipe,
    ActivityTypeAddComponent,
    IsFreeAddComponent,
    ActivityAddComponent,
    ActivityTypeUpdateComponent,
    IsFreeUpdateComponent,
    ActivityUpdateComponent,
    LoginComponent,
    RegisterComponent,
    AdminComponent,
    ProfileComponent,
    SuperuseraddComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    MatSelectModule,
    NgbModule,
    ReactiveFormsModule,
    ValidateEqualModule

  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass:AuthInterceptor,multi:true}
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
