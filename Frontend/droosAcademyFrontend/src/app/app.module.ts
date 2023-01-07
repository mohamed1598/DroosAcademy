import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { LogoComponent } from './Components/logo/logo.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { StudentLoginComponent } from './Components/login-signup/login/student-login/student-login.component';
import { StudentSignupComponent } from './Components/login-signup/signup/student-signup/student-signup.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TeacherLoginComponent } from './Components/login-signup/login/teacher-login/teacher-login.component';
import { TeacherSignupComponent } from './Components/login-signup/signup/teacher-signup/teacher-signup.component';
import { AdminLoginComponent } from './Components/login-signup/login/admin-login/admin-login.component';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StudentNavbarComponent } from './Components/studentDashboard/student-navbar/student-navbar.component';
import { StudentDashboardComponent } from './Components/studentDashboard/student-dashboard/student-dashboard.component';
import { StudentBalanceComponent } from './Components/studentDashboard/student-balance/student-balance.component';
import { StudentTeachersComponent } from './Components/studentDashboard/student-teachers/student-teachers.component';
import { StudentLecturesComponent } from './Components/studentDashboard/student-lectures/student-lectures.component';
import { TeacherCardComponent } from './Components/cards/teacher-card/teacher-card.component';
import { LectureCardComponent } from './Components/cards/lecture-card/lecture-card.component';
import { FontAwesomeModule,FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faCoffee, fas } from '@fortawesome/free-solid-svg-icons';
import { TeacherStatisticsComponent } from './Components/TeacherDashboard/teacher-statistics/teacher-statistics.component';
import { TeacherLecturesComponent } from './Components/TeacherDashboard/teacher-lectures/teacher-lectures.component';
import { TeacherPaymentoperationsComponent } from './Components/TeacherDashboard/teacher-paymentoperations/teacher-paymentoperations.component';
import { TeacherSettingsComponent } from './Components/TeacherDashboard/teacher-settings/teacher-settings.component';
import { TeacherStudentsComponent } from './Components/TeacherDashboard/teacher-students/teacher-students.component';
import { TeacherDashboardComponent } from './Components/TeacherDashboard/teacher-dashboard/teacher-dashboard.component';
import { TeacherNavbarComponent } from './Components/TeacherDashboard/teacher-navbar/teacher-navbar.component';
import { StudentHomeComponent } from './Components/home/student-home/student-home.component';
import { TeacherHomeComponent } from './Components/home/teacher-home/teacher-home.component';
import { far } from '@fortawesome/free-regular-svg-icons';
import { StudentPaymentComponent } from './Components/StudentDashboard/student-payment/student-payment.component';
import { LectureHomeComponent } from './Components/Lecture/lecture-home/lecture-home.component';
import { LectureNavbarComponent } from './Components/Lecture/lecture-navbar/lecture-navbar.component';
import { LectureExamComponent } from './Components/Lecture/lecture-exam/lecture-exam.component';
import { AdminDashboardComponent } from './Components/Admin/admin-dashboard/admin-dashboard.component';
import { AdminNavbarComponent } from './Components/Admin/admin-navbar/admin-navbar.component';
import { StudentRightComponent } from './Components/Admin/Student/student-right/student-right.component';
import { AllStudentComponent } from './Components/Admin/Student/all-student/all-student.component';
import { SearchForStudentComponent } from './Components/Admin/Student/search-for-student/search-for-student.component';
import { AdminStudentTransactionComponent } from './Components/Admin/Student/admin-student-transaction/admin-student-transaction.component';
import { AdminStudentHomeComponent } from './Components/Admin/Student/admin-student-home/admin-student-home.component';
import { AdminTeacherHomeComponent } from './Components/Admin/Teacher/admin-teacher-home/admin-teacher-home.component';
import { AllTeacherComponent } from './Components/Admin/Teacher/all-teacher/all-teacher.component';
import { TeacherRightComponent } from './Components/Admin/Teacher/teacher-right/teacher-right.component';
import { SearchForTeacherComponent } from './Components/Admin/Teacher/search-for-teacher/search-for-teacher.component';
import { AdminTeacherTransactionsComponent } from './Components/Admin/Teacher/admin-teacher-transactions/admin-teacher-transactions.component';
import { AdminSellerHomeComponent } from './Components/Admin/Seller/admin-seller-home/admin-seller-home.component';
import { AllSellerComponent } from './Components/Admin/Seller/all-seller/all-seller.component';
import { SellerTransactionComponent } from './Components/Admin/Seller/seller-transaction/seller-transaction.component';
import { SearchForSellerComponent } from './Components/Admin/Seller/search-for-seller/search-for-seller.component';
import { SellerRightComponent } from './Components/Admin/Seller/seller-right/seller-right.component';
import { CreateLectureComponent } from './Components/TeacherDashboard/create-lecture/create-lecture.component';
import { TestComponent } from './Components/test/test.component';
import { TeacherCodesComponent } from './Components/TeacherDashboard/teacher-codes/teacher-codes.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { CustomHttpInterceptor } from './Services/Animation/http-interceptor.service';
import { ExamquestionComponent } from './Components/Lecture/lecture-exam/examquestion/examquestion.component';
import { CreateExamComponent } from './Components/TeacherDashboard/create-exam/create-exam.component';
import { AddQuestionsComponent } from './Components/TeacherDashboard/create-exam/add-questions/add-questions.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LogoComponent,
    NavbarComponent,
    StudentLoginComponent,
    StudentSignupComponent,
    TeacherLoginComponent,
    TeacherSignupComponent,
    AdminLoginComponent,
    StudentNavbarComponent,
    StudentDashboardComponent,
    StudentBalanceComponent,
    StudentTeachersComponent,
    StudentLecturesComponent,
    TeacherCardComponent,
    LectureCardComponent,
    TeacherStatisticsComponent,
    TeacherLecturesComponent,
    TeacherPaymentoperationsComponent,
    TeacherSettingsComponent,
    TeacherStudentsComponent,
    TeacherDashboardComponent,
    TeacherNavbarComponent,
    StudentHomeComponent,
    TeacherHomeComponent,
    StudentPaymentComponent,
    LectureHomeComponent,
    LectureNavbarComponent,
    LectureExamComponent,
    AdminDashboardComponent,
    AdminNavbarComponent,
    StudentRightComponent,
    AllStudentComponent,
    SearchForStudentComponent,
    AdminStudentTransactionComponent,
    AdminStudentHomeComponent,
    AdminTeacherHomeComponent,
    AllTeacherComponent,
    TeacherRightComponent,
    SearchForTeacherComponent,
    AdminTeacherTransactionsComponent,
    AdminSellerHomeComponent,
    AllSellerComponent,
    SellerTransactionComponent,
    SearchForSellerComponent,
    SellerRightComponent,
    CreateLectureComponent,
    TestComponent,
    TeacherCodesComponent,
    ExamquestionComponent,
    CreateExamComponent,
    AddQuestionsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomHttpInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(library:FaIconLibrary) {
    library.addIconPacks(fas,far);
    library.addIcons(faCoffee);
  }
}
