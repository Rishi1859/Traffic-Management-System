using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Bus.DomainModels;
using BusReservationSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BusReservationSystem.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [RegularExpression(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$", ErrorMessage = "Email format is incorrect")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Name")]
            [Required]
            [StringLength(30)]
            [RegularExpression(@"^[A-Za-z\s]+${3,30}", ErrorMessage = "Please enter a valid name")]
            public string Name { get; set; }

            [Display(Name = "Street Address")]
            [StringLength(40)]
            [Required]
            [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Address is in wrong format")]
            public string Address { get; set; }

            [Display(Name = "City")]
            [StringLength(20)]
            [Required]
            [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "City is in wrong format")]
            public string City { get; set; }

            [Display(Name = "State")]
            [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "State is in wrong format")]
            [StringLength(20)]
            [Required]
            public string State { get; set; }

            [Display(Name = "Country")]
            [StringLength(20)]
            [Required]
            [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Country is in wrong format")]
            public string Country { get; set; }

            [Display(Name = "Phone Number")]
            [Required]
            [RegularExpression(@"^[6-9][0-9]{9}$", ErrorMessage = "Contact number format is incorrect")]
            public string PhoneNumber { get; set; }

            [Required]
            //[MaxLength(6)]
            public int Pincode { get; set; }

            [Required]
            //[Range(18, 80)]
            public int Age { get; set; }

            [Required(ErrorMessage = "Enter Date of Birth")]
            [Display(Name = "Date of Birth")]
            //[RegularExpression("^ ([1-9]0[1 - 9][12][0 - 9]3[01])[- /.] ([1 - 9]0[1-9]1[012])[- /.] [0-9]{4}$"
            //, ErrorMessage = "Invalid Date of Birth")]
            public DateTime DateOfBirth { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Register 
                { 
                    UserName = Input.Email, 
                    Email = Input.Email , 
                    Name=Input.Name,
                    Address = Input.Address,
                    City = Input.City,
                    State = Input.State,
                    Country = Input.Country,
                    ContactNumber = Input.PhoneNumber,
                    Pincode =Input.Pincode,
                    Age =Input.Age,
                    //Role = Input.Role,
                    DateOfBirth = Input.DateOfBirth,
                    //CustomerType = Input.CustomerType
                };
          
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
