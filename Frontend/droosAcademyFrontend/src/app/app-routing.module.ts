import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './Components/Admin/admin-dashboard/admin-dashboard.component';
import { AdminSellerHomeComponent } from './Components/Admin/Seller/admin-seller-home/admin-seller-home.component';
import { AllSellerComponent } from './Components/Admin/Seller/all-seller/all-seller.component';
import { SearchForSellerComponent } from './Components/Admin/Seller/search-for-seller/search-for-seller.component';
import { SellerTransactionComponent } from './Components/Admin/Seller/seller-transaction/seller-transaction.component';
import { AdminStudentHomeComponent } from './Components/Admin/Student/admin-student-home/admin-student-home.component';
import { AdminStudentTransactionComponent } from './Components/Admin/Student/admin-student-transaction/admin-student-transaction.component';
import { AllStudentComponent } from './Components/Admin/Student/all-student/all-student.component';
import { SearchForStudentComponent } from './Components/Admin/Student/search-for-student/search-for-student.component';
import { AdminTeacherHomeComponent } from './Components/Admin/Teacher/admin-teacher-home/admin-teacher-home.component';
import { AdminTeacherTransactionsComponent } from './Components/Admin/Teacher/admin-teacher-transactions/admin-teacher-transactions.component';
import { AllTeacherComponent } from './Components/Admin/Teacher/all-teacher/all-teacher.component';
import { SearchForTeacherComponent } from './Components/Admin/Teacher/search-for-teacher/search-for-teacher.component';
import { HomeComponent } from './Components/home/home.component';
import { StudentHomeComponent } from './Components/home/student-home/student-home.component';
import { TeacherHomeComponent } from './Components/home/teacher-home/teacher-home.component';
import { LectureExamComponent } from './Components/Lecture/lecture-exam/lecture-exam.component';
import { LectureHomeComponent } from './Components/Lecture/lecture-home/lecture-home.component';
import { AdminLoginComponent } from './Components/login-signup/login/admin-login/admin-login.component';
import { StudentLoginComponent } from './Components/login-signup/login/student-login/student-login.component';
import { TeacherLoginComponent } from './Components/login-signup/login/teacher-login/teacher-login.component';
import { StudentSignupComponent } from './Components/login-signup/signup/student-signup/student-signup.component';
import { TeacherSignupComponent } from './Components/login-signup/signup/teacher-signup/teacher-signup.component';
import { StudentBalanceComponent } from './Components/studentDashboard/student-balance/student-balance.component';
import { StudentDashboardComponent } from './Components/studentDashboard/student-dashboard/student-dashboard.component';
import { StudentLecturesComponent } from './Components/studentDashboard/student-lectures/student-lectures.component';
import { StudentPaymentComponent } from './Components/StudentDashboard/student-payment/student-payment.component';
import { StudentTeachersComponent } from './Components/studentDashboard/student-teachers/student-teachers.component';
import { AddQuestionsComponent } from './Components/TeacherDashboard/create-exam/add-questions/add-questions.component';
import { CreateExamComponent } from './Components/TeacherDashboard/create-exam/create-exam.component';
import { CreateLectureComponent } from './Components/TeacherDashboard/create-lecture/create-lecture.component';
import { TeacherCodesComponent } from './Components/TeacherDashboard/teacher-codes/teacher-codes.component';
import { TeacherDashboardComponent } from './Components/TeacherDashboard/teacher-dashboard/teacher-dashboard.component';
import { TeacherLecturesComponent } from './Components/TeacherDashboard/teacher-lectures/teacher-lectures.component';
import { TeacherPaymentoperationsComponent } from './Components/TeacherDashboard/teacher-paymentoperations/teacher-paymentoperations.component';
import { TeacherSettingsComponent } from './Components/TeacherDashboard/teacher-settings/teacher-settings.component';
import { TeacherStatisticsComponent } from './Components/TeacherDashboard/teacher-statistics/teacher-statistics.component';
import { TeacherStudentsComponent } from './Components/TeacherDashboard/teacher-students/teacher-students.component';
import { TestComponent } from './Components/test/test.component';
import { AdminAuthGuardService } from './Services/AuthGuard/admin-auth-guard.service';
import { LectureAuthGuardService } from './Services/AuthGuard/lecture-auth-guard.service';
import { StudentAuthGuardService } from './Services/AuthGuard/student-auth-guard.service';
import { TeacherAuthGuardService } from './Services/AuthGuard/teacher-auth-guard.service';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'StudentHome',component:StudentHomeComponent},
  {path:'TeacherHome',component:TeacherHomeComponent},
  {path:'StudentLogin',component:StudentLoginComponent},
  {path:'StudentSignup',component:StudentSignupComponent},
  {path:'TeacherLogin',component:TeacherLoginComponent},
  {path:'TeacherSignup',component:TeacherSignupComponent},
  {path:'AdminLogin',component:AdminLoginComponent},
  {path:'Lecture',component:LectureHomeComponent ,canActivate:[LectureAuthGuardService]},
  {path:'Test',component:TestComponent},
  {path:'Exam',component:LectureExamComponent},
  { path: 'Student', component: StudentDashboardComponent, canActivate:[StudentAuthGuardService], children: 
    [
      { path: '', component: StudentBalanceComponent},
      { path: 'Lectures', component: StudentLecturesComponent},
      { path: 'Payment', component: StudentPaymentComponent},
      { path: 'Teachers', component: StudentTeachersComponent}
    ]
  },
  { path: 'Teacher', component: TeacherDashboardComponent,canActivate:[TeacherAuthGuardService], children: 
    [
      { path: '', component: TeacherStatisticsComponent},
      { path: 'Lectures', component: TeacherLecturesComponent},
      { path: 'Students', component: TeacherStudentsComponent},
      { path: 'PaymentOperations', component: TeacherPaymentoperationsComponent},
      { path: 'Settings', component: TeacherSettingsComponent},
      { path: 'CreateLecture', component: CreateLectureComponent},
      { path: 'CreateExam', component: CreateExamComponent},
      { path: 'AddQuestions', component: AddQuestionsComponent},
      { path: 'CreateCode', component: TeacherCodesComponent},
    ]
  },
  { path: 'Admin', component: AdminDashboardComponent,canActivate:[AdminAuthGuardService], children: 
    [
      { path: '', component: AdminStudentHomeComponent, children: 
        [
          { path: '', component: AllStudentComponent},
          { path: 'SearchForStudent', component: SearchForStudentComponent},
          { path: 'studentTransaction', component: AdminStudentTransactionComponent},
        ]
      },
      { path: 'Teacher', component: AdminTeacherHomeComponent, children: 
        [
          { path: '', component: AllTeacherComponent},
          { path: 'SearchForTeacher', component: SearchForTeacherComponent},
          { path: 'TeacherTransaction', component: AdminTeacherTransactionsComponent},
        ]
      },
      { path: 'Seller', component: AdminSellerHomeComponent, children: 
        [
          { path: '', component: AllSellerComponent},
          { path: 'SearchForSeller', component: SearchForSellerComponent},
          { path: 'SellerTransaction', component: SellerTransactionComponent},
        ]
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
