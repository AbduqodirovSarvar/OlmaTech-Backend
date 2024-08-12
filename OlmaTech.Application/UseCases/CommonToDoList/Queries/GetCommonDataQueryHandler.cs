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
            AboutViewModel about = _mapper.Map<AboutViewModel>(await _appDbContext.Abouts.OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync(cancellationToken));
            List<HomePostViewModel>? homes = _mapper.Map<List<HomePostViewModel>>(await _appDbContext.HomePosts.ToListAsync(cancellationToken));
            List<ServiceViewModel>? services = _mapper.Map<List<ServiceViewModel>>(await _appDbContext.Services.ToListAsync( cancellationToken));
            List<ProjectViewModel>? projects = _mapper.Map<List<ProjectViewModel>>(await _appDbContext.Projects.ToListAsync(cancellationToken));
            List<TeamViewModel>? teams = _mapper.Map<List<TeamViewModel>>(await _appDbContext.Teams.ToListAsync(cancellationToken));
            List<ClientViewModel>? clients = _mapper.Map<List<ClientViewModel>>(await _appDbContext.Clients.ToListAsync(cancellationToken));
            List<BlogPostViewModel>? blogs = _mapper.Map<List<BlogPostViewModel>>(await _appDbContext.BlogPosts.ToListAsync(cancellationToken));
            List<ContactViewModel>? contacts = _mapper.Map<List<ContactViewModel>>(await _appDbContext.Contacts.ToListAsync(cancellationToken));

            return new CommonViewModel()
                        {
                            About = about,
                            Homes = homes,
                            Services = services,
                            Projects = projects,
                            Teams = teams,
                            Clients = clients,
                            Blogs = blogs,
                            Contacts = contacts
                        };
        }
    }
}
