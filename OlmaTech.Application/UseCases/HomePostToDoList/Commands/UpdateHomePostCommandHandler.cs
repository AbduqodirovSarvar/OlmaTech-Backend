using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.HomePostToDoList.Commands
{
    public class UpdateHomePostCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService
        ) : IRequestHandler<UpdateHomePostCommand, HomePost>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;

        public async Task<HomePost> Handle(UpdateHomePostCommand request, CancellationToken cancellationToken)
        {
            var homePost = await _appDbContext.HomePosts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                              ?? throw new Exception("Post not found");

            if (request.Photo != null)
            {
                var newPhotoName = await _fileService.SaveFileAsync(request.Photo);
                homePost.Photo = newPhotoName ?? homePost.Photo;
            }

            homePost.TitleEn = request.TitleEn ?? homePost.TitleEn;
            homePost.TitleRu = request.TitleRu ?? homePost.TitleRu;
            homePost.TitleUz = request.TitleUz ?? homePost.TitleUz;
            homePost.TitleUzRu = request.TitleUzRu ?? homePost.TitleUzRu;
            homePost.SubitleEn = request.SubtitleEn ?? homePost.SubitleEn;
            homePost.SubtitleRu = request.SubtitleRu ?? homePost.SubtitleRu;
            homePost.SubtitleUz = request.SubtitleUz ?? homePost.SubtitleUz;
            homePost.SubtitleUzRu = request.SubtitleUzRu ?? homePost.SubtitleUzRu;
            homePost.DescriptionEn = request.DescriptionEn ?? homePost.DescriptionEn;
            homePost.DescriptionRu = request.DescriptionRu ?? homePost.DescriptionRu;
            homePost.DescriptionUz = request.DescriptionUz ?? homePost.DescriptionUz;
            homePost.DescriptionUzRu = request.DescriptionUzRu ?? homePost.DescriptionUzRu;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            return homePost;
        }
    }
}
