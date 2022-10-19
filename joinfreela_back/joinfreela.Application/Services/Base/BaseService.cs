using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Common;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services.Base;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Infrastructure.Repositories.Base;

namespace joinfreela.Application.Services.Base
{
    public abstract class BaseService<Tmodel,Trequest,Tresponse> : IBaseService<Tmodel,Trequest,Tresponse>
    where Tmodel:Register
    where Trequest: RegisterViewModel
    where Tresponse: RegisterViewModel
    {
        private IBaseRepository<Tmodel> _repository { get; set; }
        private IMapper _mapper { get; set; }
        private IValidator<Trequest> _requestvalidator { get; set; }
        private IUnityOfWork _unityOfWork { get; set; }

        protected BaseService(IBaseRepository<Tmodel> repository, IMapper mapper, IValidator<Trequest> requestvalidator, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _requestvalidator = requestvalidator;
            _unityOfWork = unityOfWork;
            
        }

        public virtual async Task<PaginationResponse<Tresponse>> GetAsync(BaseParameters<Tmodel> parameters)
        {
            var page= new PaginationResponse<Tresponse>
                {
                    Skip = parameters.Skip,
                    Take = parameters.Take,
                    Data = _mapper.Map<IEnumerable<Tresponse>>(await _repository.GetAsync(parameters.Skip,parameters.Take,parameters.Filter()))
                };
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return page;
        }

        public virtual async Task<Tresponse> RegisterAsync(Trequest request)
        {
            var validationResult = _requestvalidator.Validate(request);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var model = _mapper.Map<Tmodel>(request);            
            await _repository.RegisterAsync(model);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<Tresponse>(model);
        }

        public virtual async Task<Tresponse> UpdateAsync(int id,Trequest request)
        {
            var model = await _repository.GetByIdAsync(id);
            if (model is null)
                throw new NotFoundException($"{nameof(Tmodel)} não encontrada");
            
            if(model.Id != request.Id)
                throw new BadRequestException($"{nameof(Tmodel)}Request.Id","Id's informados não são condizentes");
                                
            var validationResult = _requestvalidator.Validate(request);
            if ( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);

            _mapper.Map<Trequest,Tmodel>(request,model);
            
            //Interaction
            await _repository.UpdateAsync(model);
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<Tresponse>(model);    
            
        }

    }
}