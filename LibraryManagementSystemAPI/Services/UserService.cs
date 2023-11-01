using AutoMapper;
using LibraryManagementSystemAPI.Dto;
using LibraryManagementSystemAPI.Models;
using LibraryManagementSystemAPI.Models.Enum;
using LibraryManagementSystemAPI.Shared.Helpers;
using LibraryManagementSystemAPI.Shared.Logging;
using LibraryManagementSystemAPI.Shared.Persistence;
using LibraryManagementSystemAPI.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Services
{
    public class UserService : IUser
    {
        private readonly DataContext _DataContext;
        private readonly IMapper _Mapper;
        IAppLogger _Logger;
        public UserService(DataContext dataContext, IMapper mapper, IAppLogger logger)
        {
            this._DataContext = dataContext;
            this._Mapper = mapper;
            this._Logger = logger;
        }


        public Task<BaseResponse> AuthenticateUser(string email, string password, out UserDto? user)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> BlockUser(string Id)
        {
            BaseResponse response = new();

            try
            {
                var dataold = await this._DataContext.Users.AsNoTracking().FirstOrDefaultAsync(item => item.Id.ToString() == Id);

                if (dataold != null)
                {

                    dataold.Blocked = true;

                    dataold.UpdatedDate = DateTime.Now;

                    var resultat = _DataContext.Users.Update(dataold);
                    await SaveChange();

                    if (resultat != null)
                    {
                        _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = HelperMessage.BlockUser }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = HelperMessage.BadRequestElem(Id!) }
                        };
                        _Logger.LogInfo("Method - UpdateuserModel : Erreur de Modification d'un userModel ");
                    }
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem(Id!) }
                    };
                    _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;
        }
        public async Task<BaseResponse> DeactivateUser(string Id)
        {
            BaseResponse response = new();

            try
            {
                var dataold = await this._DataContext.Users.AsNoTracking().FirstOrDefaultAsync(item => item.Id.ToString() == Id);

                if (dataold != null)
                {

                    dataold.Active = false;

                    dataold.UpdatedDate = DateTime.Now;

                    var resultat = _DataContext.Users.Update(dataold);
                    await SaveChange();

                    if (resultat != null)
                    {
                        _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = HelperMessage.DeactivateUser }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = HelperMessage.BadRequestElem(Id!) }
                        };
                        _Logger.LogInfo("Method - UpdateuserModel : Erreur de Modification d'un userModel ");
                    }
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem(Id!) }
                    };
                    _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;

        }
        public async Task<BaseResponse> UnblockUser(string Id)
        {
            BaseResponse response = new();

            try
            {
                var dataold = await this._DataContext.Users.AsNoTracking().FirstOrDefaultAsync(item => item.Id.ToString() == Id);

                if (dataold != null)
                {

                    dataold.Blocked = false;

                    dataold.UpdatedDate = DateTime.Now;

                    var resultat = _DataContext.Users.Update(dataold);
                    await SaveChange();

                    if (resultat != null)
                    {
                        _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = HelperMessage.UnblockUser }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = HelperMessage.BadRequestElem(Id!) }
                        };
                        _Logger.LogInfo("Method - UpdateuserModel : Erreur de Modification d'un userModel ");
                    }
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem(Id!) }
                    };
                    _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;
        }
        public async Task<BaseResponse> ActivateUser(string Id ) 
        {
            BaseResponse response = new();

            try
            {
                var dataold = await this._DataContext.Users.AsNoTracking().FirstOrDefaultAsync(item => item.Id.ToString() == Id);

                if (dataold != null)
                {

                    dataold.Active = true;

                    dataold.UpdatedDate = DateTime.Now;

                    var resultat = _DataContext.Users.Update(dataold);
                    await SaveChange();

                    if (resultat != null)
                    {
                        _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = HelperMessage.ActivateUser }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = HelperMessage.BadRequestElem(Id!) }
                        };
                        _Logger.LogInfo("Method - UpdateuserModel : Erreur de Modification d'un userModel ");
                    }
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem(Id!) }
                    };
                    _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;
        }
        public Task<BaseResponse> IsEmailAvailable(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> CreateUser(UserDto user)
        {
            BaseResponse response = new();
            try
            {
                var dataExistEmail = await this._DataContext.Users.FirstOrDefaultAsync(item => item.Email!.Trim().ToUpper() == user.Email!.TrimEnd().ToUpper());
                var dataExistMobile = await this._DataContext.Users.FirstOrDefaultAsync(item => item.Mobile!.Trim().ToUpper() == user.Mobile!.TrimEnd().ToUpper());

                if (dataExistEmail != null) { 

                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status422UnprocessableEntity,
                        data = new { message = HelperMessage.BadRequestDataExist(user.Email!) }
                    };
                }
                if (dataExistMobile != null)
                {

                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status422UnprocessableEntity,
                        data = new { message = HelperMessage.BadRequestDataExist(user.Mobile!) }
                    };
                }
                else
                {

                    UserModel userModel = this._Mapper.Map<UserDto, UserModel>(user);
                    userModel.CreatedDate = DateTime.Now;
                    userModel.UpdatedDate = DateTime.Now;
                    userModel.UserType = UserType.USER;

                    await _DataContext.AddAsync(userModel);
                    await SaveChange();
                    _Logger.LogInfo("Method - CreateUser : Ajout avec succès");

                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { message = HelperMessage.OK }
                    };
                }


            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }
            return response;
        }


        public async Task<BaseResponse> DeleteById(string Id)
        {
            BaseResponse response = new();
            try
            {
                var data = await this._DataContext.Users.FirstOrDefaultAsync(item => item.Id.ToString() == Id);

                if (data != null)
                {
                    this._DataContext.Users.Remove(data);

                    await SaveChange();

                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { message = HelperMessage.Deleted }
                    };

                    _Logger.LogInfo("Methode - Deleted Suppression avec succès");
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem(Id) }
                    };

                    _Logger.LogWarn("Methode - Deleted Aucun");
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;
        }

        public async Task<BaseResponse> GetUserById(string Id)
        {
            BaseResponse response = new();

            try
            {
                var data = await this._DataContext.Users.FirstOrDefaultAsync(item => item.Id.ToString() == Id);


                if (data != null)
                {
                    var lsUser = _Mapper.Map<UserDto>(data);

                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { lsUser }
                    };
                    _Logger.LogInfo("Methode - GetUser :  Le User");
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem(Id) }
                    };
                    _Logger.LogWarn("Methode - GetUser : Aucun user ");
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;
        }

        public async Task<BaseResponse> GetUsers()
        {
            BaseResponse response = new();
            List<UserDto> lsUsers = new();

            var data = await this._DataContext.Users.ToListAsync();
            try
            {

                if (data != null && data.Count > 0)
                {

                    data.ForEach(user =>
                    {
                        var dataBiding = _Mapper.Map<UserDto>(user);
                        lsUsers.Add(dataBiding);
                    });

                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status200OK,
                        data = new { lsUsers }
                    };


                    _Logger.LogInfo("Methode - GetAllsUsers Liste de tous les users");

                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem("lsUsers") }
                    };

                    _Logger.LogWarn("Methode - GetAlllsProducts : Aucun user ");
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;
        }


        public async Task<bool> SaveChange()
        {
            var saved = await _DataContext.SaveChangesAsync();
            return saved > 0 ? true : false;
        }


        public async Task<BaseResponse> UpdateUser(UserDto user)
        {
            BaseResponse response = new();

            try
            {

                var dataold = await this._DataContext.Users.AsNoTracking().FirstOrDefaultAsync(item => item.Id.ToString() == user.Id);

                if (dataold != null)
                {
                    UserModel userModel = this._Mapper.Map<UserDto, UserModel>(user);

                    userModel.FirstName = user.FirstName ?? dataold.FirstName;
                    userModel.LastName = user.LastName ?? dataold.LastName;
                    userModel.Email = user.Email ?? dataold.Email;
                    userModel.Mobile = user.Mobile ?? dataold.Mobile;
                   
                    userModel.UpdatedDate = DateTime.Now;

                    var resultat = _DataContext.Users.Update(userModel);
                    await SaveChange();

                    if (resultat != null)
                    {
                        _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");

                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status200OK,
                            data = new { message = HelperMessage.Updated }
                        };
                    }
                    else
                    {
                        response = new BaseResponse
                        {
                            status_code = StatusCodes.Status400BadRequest,
                            data = new { message = HelperMessage.BadRequestElem(user.Id!) }
                        };
                        _Logger.LogInfo("Method - UpdateuserModel : Erreur de Modification d'un userModel ");
                    }
                }
                else
                {
                    response = new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound,
                        data = new { message = HelperMessage.NotFoundElem(user.Id!) }
                    };
                    _Logger.LogInfo("Method - UpdateuserModel : Modification avec succès d'un userModel ");
                }

            }
            catch (Exception ex)
            {
                _Logger.LogError(GetType().Name, ex);
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = HelperMessage.InternalServerError + ex.Message }
                };
            }

            return response;
        }

    }
}
