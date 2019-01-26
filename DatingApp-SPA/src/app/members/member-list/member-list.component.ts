import { User } from './../../_models/user';
import { Pagination } from './../../_models/pagination';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { log } from 'util';
import { PaginationResult } from 'src/app/_models/PaginationResult';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  users: User[];
  user: User = JSON.parse(localStorage.getItem('currentUser'));
  genderList = [{ value: 1, display: 'Female' }, { value: 2, display: 'Male' }];
  userParams: any = {};
  pagination: Pagination;

  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.users = data.users.results;
      this.pagination = data.users.pagination;
      console.log(data.users);
    });

    this.userParams.genderId = this.user.genderId === 1 ? 2 : 1;
    this.userParams.minAge = 18;
    this.userParams.maxAge = 50;
    this.userParams.orderBy = 'lastActive';
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadUsers();
  }

  loadUsers() {
    this.userService
      .getUsers(
        this.pagination.currentPage,
        this.pagination.itemsPerPage,
        this.userParams
      )
      .subscribe(
        (res: PaginationResult<User[]>) => {
          this.users = res.results;
          this.pagination = res.pagination;
        },
        error => {
          this.alertify.error(error);
        }
      );
      console.log(this.users);

  }


  resetFilters() {
    this.userParams.genderId = this.user.genderId === 1 ? 2 : 1;
    this.userParams.minAge = 18;
    this.userParams.maxAge = 50;
    this.loadUsers();
  }
}
