﻿using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Base.Application.Pipelines.Caching;
using Base.Application.Pipelines.Logging;
using Base.Application.Pipelines.Transaction;
using Contracts.Product;
using Domain.Entites;
using MassTransit;
using MediatR;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsNew { get; set; }
        public bool IsAvailable { get; set; }
        public string Condition { get; set; }
        public string Manufacturer { get; set; }
        public bool IsFeatured { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int ViewCount { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? ModelId { get; set; }
        public Guid SubCategoryId { get; set; }

        public string? CacheKey => "";

        public bool BypassCache => false;

        public string? CacheGroupKey => "GetProducts";

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinessRules _productBusinessRules;
            private readonly IPublishEndpoint _publishEndpoint;

            public CreateProductCommandHandler(IProductRepository ProductRepository, IMapper mapper, ProductBusinessRules ProductBusinessRules, IPublishEndpoint publishEndpoint)
            {
                _productRepository = ProductRepository;
                _mapper = mapper;
                _productBusinessRules = ProductBusinessRules;
                _publishEndpoint = publishEndpoint;
            }

            public async Task<CreatedProductResponse>? Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {

                //await _productBusinessRules.ProductNameCannotBeDuplicatedWhenInserted(request.Name);

                var entity = _mapper.Map<Product>(request);
                entity.Id = Guid.NewGuid();

                // hatalı kullanım 

                var published = _mapper.Map<CreatedProductResponse>(entity);
                await _publishEndpoint.Publish(published);

                await _productRepository.AddAsync(entity);

                return new CreatedProductResponse
                {
                    Id = entity.Id,
                };
            }
        }
    }
}
