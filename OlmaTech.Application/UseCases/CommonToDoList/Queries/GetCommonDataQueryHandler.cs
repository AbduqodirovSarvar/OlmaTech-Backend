using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.CommonToDoList.Queries
{
    public class GetCommonDataQueryHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<GetCommonDataQuery, CommonViewModel>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CommonViewModel> Handle(GetCommonDataQuery request, CancellationToken cancellationToken)
        {
            var aboutTask = _appDbContext.Abouts.AsNoTracking().OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync(cancellationToken);
            var homesTask = _appDbContext.HomePosts.AsNoTracking().ToListAsync(cancellationToken);
            var servicesTask = _appDbContext.Services.AsNoTracking().ToListAsync(cancellationToken);
            var projectsTask = _appDbContext.Projects.AsNoTracking().ToListAsync(cancellationToken);
            var teamsTask = _appDbContext.Teams.AsNoTracking().ToListAsync(cancellationToken);
            var clientsTask = _appDbContext.Clients.AsNoTracking().ToListAsync(cancellationToken);
            var blogsTask = _appDbContext.BlogPosts.AsNoTracking().ToListAsync(cancellationToken);
            var contactsTask = _appDbContext.Contacts.AsNoTracking().ToListAsync(cancellationToken);

            await Task.WhenAll(aboutTask, homesTask, servicesTask, projectsTask, teamsTask, clientsTask, blogsTask, contactsTask);

            return new CommonViewModel()
            {
                About = _mapper.Map<AboutViewModel>(await aboutTask),
                Homes = _mapper.Map<List<HomePostViewModel>>(await homesTask),
                Services = _mapper.Map<List<ServiceViewModel>>(await servicesTask),
                Projects = _mapper.Map<List<ProjectViewModel>>(await projectsTask),
                Teams = _mapper.Map<List<TeamViewModel>>(await teamsTask),
                Clients = _mapper.Map<List<ClientViewModel>>(await clientsTask),
                Blogs = _mapper.Map<List<BlogPostViewModel>>(await blogsTask),
                Contacts = _mapper.Map<List<ContactViewModel>>(await contactsTask)
            };
        }
    }
}
